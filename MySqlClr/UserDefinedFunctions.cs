//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using Microsoft.SqlServer.Server;
using System.Security.Cryptography;
using System.IO;

public partial class UserDefinedFunctions
{
    #region Local Variables

    // Current 24 byte or 192 bit key and IV for TripleDES
    private readonly static byte[] KEY = { 32, 156, 53, 167, 38, 38, 211, 14, 15, 167, 64, 187, 46, 210, 225, 12, 34, 114, 11, 204, 119, 88, 181, 199 };
    private readonly static byte[] VECTOR = { 111, 123, 216, 89, 6, 79, 137, 56, 42, 5, 62, 88, 114, 7, 219, 13, 128, 100, 200, 58, 173, 10, 121, 188 };

    // Old Database 24 byte or 192 bit key and IV for TripleDES
    private readonly static byte[] DB_KEY = { 11, 146, 50, 167, 35, 38, 211, 14, 15, 167, 64, 187, 46, 210, 220, 12, 39, 114, 11, 214, 109, 88, 183, 200 };
    private readonly static byte[] DB_VECTOR = { 101, 115, 211, 59, 8, 78, 187, 56, 42, 5, 62, 88, 114, 7, 218, 13, 128, 100, 208, 58, 183, 10, 128, 188 };

    #endregion

    #region Public Methods

    /// <summary>
    /// This function will attempt to encrypt a string using the current encryption keys.  If the string will not encrypt,
    /// the string is returned as-is.
    /// </summary>
    /// <param name="value">input string to be encrypted</param>
    /// <returns>Encrypted string</returns>
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static string Crypto(string value)
    {
        string response = String.Empty;

        try //Always encrypt in current encryption key
        {
            response = Encrypt3DES(value, KEY, VECTOR);
        }
        catch //If you can't encrypt, return the value so we can fix it later.
        {
            response = value;
        }

        return response;
    }

    /// <summary>
    /// This function will attempt to decrypt a string.  Several decryption keys are supported.
    /// If there is ever a security issue, we could change this function to support a password.
    /// </summary>
    /// <param name="value">encrypted string to decrypt</param>
    /// <returns>Decrypted string</returns>
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static string Decrypt(string value)
    {
        string response = string.Empty;
        try //decrypting using regular key
        {
            response = Decrypt3DES(value, KEY, VECTOR);
        }
        catch //could not decrypt using regular key
        {
            try //try to decrypt using old db key
            {
                response = Decrypt3DES(value, DB_KEY, DB_VECTOR);
            }
            catch //Cannot decrypt value, return it as-is so it doesn't blow up SQL Server
            {
                response = value;
            }
        }

        return response;
    }

    /// <summary>
    /// This function supports converting encrypted strings to the current encryption
    /// methodology.   If we change keys, we should update this function to support
    /// decrypting with the old keys and re-encrypting with the new keys.
    /// </summary>
    /// <param name="value">encrypted string to decrypt</param>
    /// <returns>Decrypted string</returns>
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static string CryptoTo3Des(string value)
    {
        string response = string.Empty;
        try //converting from DB to regular keys
        {
            response = Decrypt3DES(value, DB_KEY, DB_VECTOR);
            response = Encrypt3DES(response, KEY, VECTOR);
        }
        catch //already in regular key mode...return the regular key.
        {
            response = value;
        }

        return response;
    }

    #endregion

    #region Private Methods

    private static string Encrypt3DES(string value, byte[] key, byte[] vector)
    {
        if (!String.IsNullOrEmpty(value))
        {
            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(key, vector), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            // convert back to a string
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
        else
            return "";
    }

    private static string Decrypt3DES(string value, byte[] key, byte[] vector)
    {
        if (!String.IsNullOrEmpty(value))
        {
            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            // convert from string to byte array
            byte[] buffer = Convert.FromBase64String(value);
            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(key, vector), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        else
            return "";
    }

    #endregion
}
