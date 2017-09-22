using System;
using System.Windows.Forms;
using Incomm.Libraries.Cryptography;

namespace TestStuffWin
{
    public partial class Cryptography : Form
    {
        public Cryptography()
        {
            InitializeComponent();
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtEncryptResult.Text = GetEncryptedValue(txtEncryptValue.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtDecryptResult.Text = GetDecryptedValue(txtDecryptValue.Text);
        }

        private string GetEncryptedValue(string value)
        {
            try
            {
                return EncryptDecrypt.EncryptTripleDES(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Encryption failed.";
            }
        }

        private string GetDecryptedValue(string value)
        {
            string decryptedValue;
            return (EncryptDecrypt.TryDecryptTripleDES(value, out decryptedValue))
                ? decryptedValue
                : "Decryption failed.";
        }

        private void txtEncryptValue_TextChanged(object sender, EventArgs e)
        {
            txtEncryptResult.Text = null;
        }

        private void txtDecryptValue_TextChanged(object sender, EventArgs e)
        {
            txtDecryptResult.Text = null;
        }

        private void btnEncryptPaste_Click(object sender, EventArgs e)
        {
            txtEncryptValue.Text = Clipboard.GetText();
        }

        private void btnEncryptCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEncryptResult.Text))
            {
                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(txtEncryptResult.Text ?? "");
            }
        }

        private void btnDecryptPaste_Click(object sender, EventArgs e)
        {
            txtDecryptValue.Text = Clipboard.GetText();
        }

        private void btnDecryptCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecryptResult.Text))
            {
                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(txtDecryptResult.Text);
            }
        }
    }
}
