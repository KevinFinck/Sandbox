namespace TestStuffWin
{
    partial class Cryptography
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDecryptValue = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtDecryptResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncryptResult = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtEncryptValue = new System.Windows.Forms.TextBox();
            this.btnEncryptPaste = new System.Windows.Forms.Button();
            this.btnEncryptCopy = new System.Windows.Forms.Button();
            this.btnDecryptPaste = new System.Windows.Forms.Button();
            this.btnDecryptCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDecryptValue
            // 
            this.txtDecryptValue.Location = new System.Drawing.Point(85, 120);
            this.txtDecryptValue.Name = "txtDecryptValue";
            this.txtDecryptValue.Size = new System.Drawing.Size(293, 22);
            this.txtDecryptValue.TabIndex = 8;
            this.txtDecryptValue.TextChanged += new System.EventHandler(this.txtDecryptValue_TextChanged);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(85, 148);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(85, 31);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtDecryptResult
            // 
            this.txtDecryptResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtDecryptResult.Location = new System.Drawing.Point(519, 120);
            this.txtDecryptResult.Name = "txtDecryptResult";
            this.txtDecryptResult.ReadOnly = true;
            this.txtDecryptResult.Size = new System.Drawing.Size(293, 22);
            this.txtDecryptResult.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Result:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Result:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Value:";
            // 
            // txtEncryptResult
            // 
            this.txtEncryptResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtEncryptResult.Location = new System.Drawing.Point(519, 34);
            this.txtEncryptResult.Name = "txtEncryptResult";
            this.txtEncryptResult.ReadOnly = true;
            this.txtEncryptResult.Size = new System.Drawing.Size(293, 22);
            this.txtEncryptResult.TabIndex = 5;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(85, 62);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(85, 31);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtEncryptValue
            // 
            this.txtEncryptValue.Location = new System.Drawing.Point(85, 34);
            this.txtEncryptValue.Name = "txtEncryptValue";
            this.txtEncryptValue.Size = new System.Drawing.Size(293, 22);
            this.txtEncryptValue.TabIndex = 1;
            this.txtEncryptValue.TextChanged += new System.EventHandler(this.txtEncryptValue_TextChanged);
            // 
            // btnEncryptPaste
            // 
            this.btnEncryptPaste.Location = new System.Drawing.Point(384, 33);
            this.btnEncryptPaste.Name = "btnEncryptPaste";
            this.btnEncryptPaste.Size = new System.Drawing.Size(65, 25);
            this.btnEncryptPaste.TabIndex = 2;
            this.btnEncryptPaste.Text = "Paste";
            this.btnEncryptPaste.UseVisualStyleBackColor = true;
            this.btnEncryptPaste.Click += new System.EventHandler(this.btnEncryptPaste_Click);
            // 
            // btnEncryptCopy
            // 
            this.btnEncryptCopy.Location = new System.Drawing.Point(818, 33);
            this.btnEncryptCopy.Name = "btnEncryptCopy";
            this.btnEncryptCopy.Size = new System.Drawing.Size(65, 25);
            this.btnEncryptCopy.TabIndex = 6;
            this.btnEncryptCopy.Text = "Copy";
            this.btnEncryptCopy.UseVisualStyleBackColor = true;
            this.btnEncryptCopy.Click += new System.EventHandler(this.btnEncryptCopy_Click);
            // 
            // btnDecryptPaste
            // 
            this.btnDecryptPaste.Location = new System.Drawing.Point(384, 119);
            this.btnDecryptPaste.Name = "btnDecryptPaste";
            this.btnDecryptPaste.Size = new System.Drawing.Size(65, 25);
            this.btnDecryptPaste.TabIndex = 9;
            this.btnDecryptPaste.Text = "Paste";
            this.btnDecryptPaste.UseVisualStyleBackColor = true;
            this.btnDecryptPaste.Click += new System.EventHandler(this.btnDecryptPaste_Click);
            // 
            // btnDecryptCopy
            // 
            this.btnDecryptCopy.Location = new System.Drawing.Point(818, 119);
            this.btnDecryptCopy.Name = "btnDecryptCopy";
            this.btnDecryptCopy.Size = new System.Drawing.Size(65, 25);
            this.btnDecryptCopy.TabIndex = 13;
            this.btnDecryptCopy.Text = "Copy";
            this.btnDecryptCopy.UseVisualStyleBackColor = true;
            this.btnDecryptCopy.Click += new System.EventHandler(this.btnDecryptCopy_Click);
            // 
            // Cryptography
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 216);
            this.Controls.Add(this.btnDecryptCopy);
            this.Controls.Add(this.btnDecryptPaste);
            this.Controls.Add(this.btnEncryptCopy);
            this.Controls.Add(this.btnEncryptPaste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncryptResult);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtEncryptValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDecryptResult);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtDecryptValue);
            this.Name = "Cryptography";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TripleDES Cryptography";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDecryptValue;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtDecryptResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEncryptResult;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtEncryptValue;
        private System.Windows.Forms.Button btnEncryptPaste;
        private System.Windows.Forms.Button btnEncryptCopy;
        private System.Windows.Forms.Button btnDecryptPaste;
        private System.Windows.Forms.Button btnDecryptCopy;
    }
}

