using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace CertMaker
{
    public class CertMan
    {

        public static void MyMakeIt(string publicKeyFilename, string privateKeyFilename, string outputFilename, string password)
        {
            var publicKey = File.ReadAllBytes(publicKeyFilename);
            var privateKey = File.ReadAllBytes(privateKeyFilename);
            var certificate = new X509Certificate2(
                publicKeyFilename, password,
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            var cspParams = new CspParameters
            {
                ProviderType = 1,
                Flags = CspProviderFlags.UseMachineKeyStore,
                KeyContainerName = Guid.NewGuid().ToString().ToUpperInvariant()
            };
            var rsa = new RSACryptoServiceProvider(cspParams);


            //int size = publicKey.Length - 12;
            //byte[] pkey = new byte[148];
            //Buffer.BlockCopy(pubkey, 12, pkey, 0, 148);

            RSACryptoServiceProvider r = new RSACryptoServiceProvider();
            r.ImportCspBlob(publicKey);

            rsa.ImportCspBlob(privateKey);
            rsa.PersistKeyInCsp = true;
            certificate.PrivateKey = rsa;

            certificate.Export(X509ContentType.Pfx, password);
            File.WriteAllBytes(outputFilename, certificate.RawData);
        }

        public void MakeItVer3()
        {
            //byte[] certificateData = certificate.Export(X509ContentType.Pfx, "YourPassword");
            //File.WriteAllBytes(@"C:\YourCert.pfx", certificateData);
        }

        public void MakeItVer1()
        {
            // Import the certficate
            X509Certificate2 cert = new X509Certificate2("c:\\cert.cer");

            // Import the private key
            X509Certificate2 pvk = new X509Certificate2("c:\\key.pvk");

            // Or import the private key - Alternative method
            //X509DecryptString(token, @"c:\CA.pvk", "mypassword");

            // Export the PFX file
            //certificate.Export(X509ContentType.Pfx, "YourPassword");
            //File.WriteAllBytes(@"C:\YourCert.pfx", certificateData);
        }

        public void MakeItVer2()
        {
            
            /*
            var PublicKey = AssemblyUtility.GetEmbeddedFileAsByteArray("Cert.cer");
            var PrivateKey = AssemblyUtility.GetEmbeddedFileAsByteArray("PrivateKey.pvk");
            var certificate = new X509Certificate2(
                PublicKey, string.Empty,
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            var cspParams = new CspParameters
            {
            ProviderType = 1,
            Flags = CspProviderFlags.UseMachineKeyStore,
            KeyContainerName = Guid.NewGuid().ToString().ToUpperInvariant()
            };
            var rsa = new RSACryptoServiceProvider(cspParams);

            rsa.ImportCspBlob(ExtractPrivateKeyBlobFromPvk(PrivateKey));
            rsa.PersistKeyInCsp = true;
            certificate.PrivateKey = rsa;

            certificate.Export(X509ContentType.Pfx, "YourPassword");
            File.WriteAllBytes(@"C:\YourCert.pfx", certificateData);
            */
        }

    }
}
