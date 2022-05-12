namespace client
{
    partial class ClientForm
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
            this.connectBox = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.portInput = new System.Windows.Forms.TextBox();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newUserBox = new System.Windows.Forms.GroupBox();
            this.createUserButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.surnameInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectBox.SuspendLayout();
            this.newUserBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectBox
            // 
            this.connectBox.Controls.Add(this.connectButton);
            this.connectBox.Controls.Add(this.portInput);
            this.connectBox.Controls.Add(this.ipInput);
            this.connectBox.Controls.Add(this.label2);
            this.connectBox.Controls.Add(this.label1);
            this.connectBox.Location = new System.Drawing.Point(12, 12);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(189, 107);
            this.connectBox.TabIndex = 0;
            this.connectBox.TabStop = false;
            this.connectBox.Text = "Connect";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(9, 71);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(167, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(76, 45);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(100, 20);
            this.portInput.TabIndex = 1;
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(76, 19);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(100, 20);
            this.ipInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // newUserBox
            // 
            this.newUserBox.Controls.Add(this.createUserButton);
            this.newUserBox.Controls.Add(this.label6);
            this.newUserBox.Controls.Add(this.label5);
            this.newUserBox.Controls.Add(this.passwordInput);
            this.newUserBox.Controls.Add(this.label4);
            this.newUserBox.Controls.Add(this.userNameInput);
            this.newUserBox.Controls.Add(this.surnameInput);
            this.newUserBox.Controls.Add(this.nameInput);
            this.newUserBox.Controls.Add(this.label3);
            this.newUserBox.Location = new System.Drawing.Point(12, 125);
            this.newUserBox.Name = "newUserBox";
            this.newUserBox.Size = new System.Drawing.Size(189, 156);
            this.newUserBox.TabIndex = 1;
            this.newUserBox.TabStop = false;
            this.newUserBox.Text = "Create User";
            this.newUserBox.Visible = false;
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(9, 124);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(167, 23);
            this.createUserButton.TabIndex = 2;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Username";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(76, 98);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '*';
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Surname";
            // 
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(76, 72);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(100, 20);
            this.userNameInput.TabIndex = 5;
            // 
            // surnameInput
            // 
            this.surnameInput.Location = new System.Drawing.Point(76, 46);
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.Size = new System.Drawing.Size(100, 20);
            this.surnameInput.TabIndex = 4;
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(76, 20);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 20);
            this.nameInput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(207, 12);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(322, 269);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Location = new System.Drawing.Point(454, 287);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 318);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.newUserBox);
            this.Controls.Add(this.connectBox);
            this.MinimumSize = new System.Drawing.Size(557, 357);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.connectBox.ResumeLayout(false);
            this.connectBox.PerformLayout();
            this.newUserBox.ResumeLayout(false);
            this.newUserBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox connectBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox newUserBox;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.TextBox surnameInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button disconnectButton;
    }
}