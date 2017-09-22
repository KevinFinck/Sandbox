namespace AsyncExceptionTest
{
    partial class zzfrmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpExceptionType = new System.Windows.Forms.GroupBox();
            this.radAsyncVoidAwait = new System.Windows.Forms.RadioButton();
            this.radVoidNoWait = new System.Windows.Forms.RadioButton();
            this.radAsyncVoidAwaitWithTry = new System.Windows.Forms.RadioButton();
            this.radTaskNoWait = new System.Windows.Forms.RadioButton();
            this.radTaskAwait = new System.Windows.Forms.RadioButton();
            this.radAwaitTaskAwait = new System.Windows.Forms.RadioButton();
            this.radAwaitTaskNoWait = new System.Windows.Forms.RadioButton();
            this.radAwaitTaskAwaitNoTry = new System.Windows.Forms.RadioButton();
            this.radTaskNoWaitNoTry = new System.Windows.Forms.RadioButton();
            this.grpExceptionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(269, 63);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(812, 504);
            this.txtLog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log:";
            // 
            // grpExceptionType
            // 
            this.grpExceptionType.Controls.Add(this.radAwaitTaskAwaitNoTry);
            this.grpExceptionType.Controls.Add(this.radTaskNoWaitNoTry);
            this.grpExceptionType.Controls.Add(this.radAwaitTaskAwait);
            this.grpExceptionType.Controls.Add(this.radAwaitTaskNoWait);
            this.grpExceptionType.Controls.Add(this.radTaskAwait);
            this.grpExceptionType.Controls.Add(this.radTaskNoWait);
            this.grpExceptionType.Controls.Add(this.radAsyncVoidAwaitWithTry);
            this.grpExceptionType.Controls.Add(this.radAsyncVoidAwait);
            this.grpExceptionType.Controls.Add(this.radVoidNoWait);
            this.grpExceptionType.Location = new System.Drawing.Point(12, 40);
            this.grpExceptionType.Name = "grpExceptionType";
            this.grpExceptionType.Size = new System.Drawing.Size(251, 379);
            this.grpExceptionType.TabIndex = 5;
            this.grpExceptionType.TabStop = false;
            this.grpExceptionType.Text = "Select type of exception:";
            // 
            // radAsyncVoidAwait
            // 
            this.radAsyncVoidAwait.AutoSize = true;
            this.radAsyncVoidAwait.Location = new System.Drawing.Point(6, 65);
            this.radAsyncVoidAwait.Name = "radAsyncVoidAwait";
            this.radAsyncVoidAwait.Size = new System.Drawing.Size(136, 21);
            this.radAsyncVoidAwait.TabIndex = 6;
            this.radAsyncVoidAwait.TabStop = true;
            this.radAsyncVoidAwait.Text = "Async Void Await";
            this.radAsyncVoidAwait.UseVisualStyleBackColor = true;
            // 
            // radVoidNoWait
            // 
            this.radVoidNoWait.AutoSize = true;
            this.radVoidNoWait.Location = new System.Drawing.Point(6, 38);
            this.radVoidNoWait.Name = "radVoidNoWait";
            this.radVoidNoWait.Size = new System.Drawing.Size(111, 21);
            this.radVoidNoWait.TabIndex = 5;
            this.radVoidNoWait.TabStop = true;
            this.radVoidNoWait.Text = "Void No Wait";
            this.radVoidNoWait.UseVisualStyleBackColor = true;
            // 
            // radAsyncVoidAwaitWithTry
            // 
            this.radAsyncVoidAwaitWithTry.AutoSize = true;
            this.radAsyncVoidAwaitWithTry.Location = new System.Drawing.Point(6, 92);
            this.radAsyncVoidAwaitWithTry.Name = "radAsyncVoidAwaitWithTry";
            this.radAsyncVoidAwaitWithTry.Size = new System.Drawing.Size(193, 21);
            this.radAsyncVoidAwaitWithTry.TabIndex = 7;
            this.radAsyncVoidAwaitWithTry.TabStop = true;
            this.radAsyncVoidAwaitWithTry.Text = "Async Void Await With Try";
            this.radAsyncVoidAwaitWithTry.UseVisualStyleBackColor = true;
            // 
            // radTaskNoWait
            // 
            this.radTaskNoWait.AutoSize = true;
            this.radTaskNoWait.Location = new System.Drawing.Point(6, 119);
            this.radTaskNoWait.Name = "radTaskNoWait";
            this.radTaskNoWait.Size = new System.Drawing.Size(114, 21);
            this.radTaskNoWait.TabIndex = 8;
            this.radTaskNoWait.TabStop = true;
            this.radTaskNoWait.Text = "Task No Wait";
            this.radTaskNoWait.UseVisualStyleBackColor = true;
            // 
            // radTaskAwait
            // 
            this.radTaskAwait.AutoSize = true;
            this.radTaskAwait.Location = new System.Drawing.Point(6, 146);
            this.radTaskAwait.Name = "radTaskAwait";
            this.radTaskAwait.Size = new System.Drawing.Size(97, 21);
            this.radTaskAwait.TabIndex = 9;
            this.radTaskAwait.TabStop = true;
            this.radTaskAwait.Text = "Task Await";
            this.radTaskAwait.UseVisualStyleBackColor = true;
            // 
            // radAwaitTaskAwait
            // 
            this.radAwaitTaskAwait.AutoSize = true;
            this.radAwaitTaskAwait.Location = new System.Drawing.Point(6, 200);
            this.radAwaitTaskAwait.Name = "radAwaitTaskAwait";
            this.radAwaitTaskAwait.Size = new System.Drawing.Size(143, 21);
            this.radAwaitTaskAwait.TabIndex = 11;
            this.radAwaitTaskAwait.TabStop = true;
            this.radAwaitTaskAwait.Text = "Await - Task Await";
            this.radAwaitTaskAwait.UseVisualStyleBackColor = true;
            // 
            // radAwaitTaskNoWait
            // 
            this.radAwaitTaskNoWait.AutoSize = true;
            this.radAwaitTaskNoWait.Location = new System.Drawing.Point(6, 173);
            this.radAwaitTaskNoWait.Name = "radAwaitTaskNoWait";
            this.radAwaitTaskNoWait.Size = new System.Drawing.Size(160, 21);
            this.radAwaitTaskNoWait.TabIndex = 10;
            this.radAwaitTaskNoWait.TabStop = true;
            this.radAwaitTaskNoWait.Text = "Await - Task No Wait";
            this.radAwaitTaskNoWait.UseVisualStyleBackColor = true;
            // 
            // radAwaitTaskAwaitNoTry
            // 
            this.radAwaitTaskAwaitNoTry.AutoSize = true;
            this.radAwaitTaskAwaitNoTry.Location = new System.Drawing.Point(6, 254);
            this.radAwaitTaskAwaitNoTry.Name = "radAwaitTaskAwaitNoTry";
            this.radAwaitTaskAwaitNoTry.Size = new System.Drawing.Size(190, 21);
            this.radAwaitTaskAwaitNoTry.TabIndex = 13;
            this.radAwaitTaskAwaitNoTry.TabStop = true;
            this.radAwaitTaskAwaitNoTry.Text = "Await - Task Await No Try";
            this.radAwaitTaskAwaitNoTry.UseVisualStyleBackColor = true;
            // 
            // radTaskNoWaitNoTry
            // 
            this.radTaskNoWaitNoTry.AutoSize = true;
            this.radTaskNoWaitNoTry.Location = new System.Drawing.Point(6, 227);
            this.radTaskNoWaitNoTry.Name = "radTaskNoWaitNoTry";
            this.radTaskNoWaitNoTry.Size = new System.Drawing.Size(207, 21);
            this.radTaskNoWaitNoTry.TabIndex = 12;
            this.radTaskNoWaitNoTry.TabStop = true;
            this.radTaskNoWaitNoTry.Text = "Await - Task No Wait No Try";
            this.radTaskNoWaitNoTry.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 579);
            this.Controls.Add(this.grpExceptionType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Async Exception Tests";
            this.grpExceptionType.ResumeLayout(false);
            this.grpExceptionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpExceptionType;
        private System.Windows.Forms.RadioButton radTaskAwait;
        private System.Windows.Forms.RadioButton radTaskNoWait;
        private System.Windows.Forms.RadioButton radAsyncVoidAwaitWithTry;
        private System.Windows.Forms.RadioButton radAsyncVoidAwait;
        private System.Windows.Forms.RadioButton radVoidNoWait;
        private System.Windows.Forms.RadioButton radAwaitTaskAwait;
        private System.Windows.Forms.RadioButton radAwaitTaskNoWait;
        private System.Windows.Forms.RadioButton radAwaitTaskAwaitNoTry;
        private System.Windows.Forms.RadioButton radTaskNoWaitNoTry;
    }
}

