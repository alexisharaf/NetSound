namespace NetSound
{
    partial class MainForm
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
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.startTalkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.localIPcomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(125, 72);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(180, 20);
            this.ipAddressTextBox.TabIndex = 0;
            // 
            // startTalkButton
            // 
            this.startTalkButton.Location = new System.Drawing.Point(172, 113);
            this.startTalkButton.Name = "startTalkButton";
            this.startTalkButton.Size = new System.Drawing.Size(75, 23);
            this.startTalkButton.TabIndex = 1;
            this.startTalkButton.Text = "Start Talk";
            this.startTalkButton.UseVisualStyleBackColor = true;
            this.startTalkButton.Click += new System.EventHandler(this.startTalkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remote IP:";
            // 
            // localIPcomboBox
            // 
            this.localIPcomboBox.FormattingEnabled = true;
            this.localIPcomboBox.Location = new System.Drawing.Point(126, 25);
            this.localIPcomboBox.Name = "localIPcomboBox";
            this.localIPcomboBox.Size = new System.Drawing.Size(179, 21);
            this.localIPcomboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Local IP:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 200);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localIPcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startTalkButton);
            this.Controls.Add(this.ipAddressTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.Button startTalkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox localIPcomboBox;
        private System.Windows.Forms.Label label2;
    }
}

