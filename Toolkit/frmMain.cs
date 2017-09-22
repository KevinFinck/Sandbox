using System;
using System.Windows.Forms;

namespace Toolkit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDecrypted.Text = Decrypt(txtEncrypted.Text);
        }
        public string Decrypt(string value)
        {
            return Incomm.Libraries.Cryptography.EncryptDecrypt.DecryptTripleDES(value);
        }

    }
}
