﻿namespace client
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
            this.label5 = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.createUserButton = new System.Windows.Forms.Button();
            this.newPostBox = new System.Windows.Forms.GroupBox();
            this.requestPostButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.connectBox.SuspendLayout();
            this.newPostBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectBox
            // 
            this.connectBox.Controls.Add(this.connectButton);
            this.connectBox.Controls.Add(this.portInput);
            this.connectBox.Controls.Add(this.label5);
            this.connectBox.Controls.Add(this.ipInput);
            this.connectBox.Controls.Add(this.label2);
            this.connectBox.Controls.Add(this.label1);
            this.connectBox.Controls.Add(this.userNameInput);
            this.connectBox.Location = new System.Drawing.Point(12, 12);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(189, 133);
            this.connectBox.TabIndex = 0;
            this.connectBox.TabStop = false;
            this.connectBox.Text = "Connect";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(9, 97);
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
            this.portInput.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Username";
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
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(76, 71);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(100, 20);
            this.userNameInput.TabIndex = 3;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(207, 12);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(446, 363);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(578, 381);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Post";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(6, 162);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(167, 23);
            this.createUserButton.TabIndex = 2;
            this.createUserButton.Text = "Send Post";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // newPostBox
            // 
            this.newPostBox.Controls.Add(this.requestPostButton);
            this.newPostBox.Controls.Add(this.richTextBox1);
            this.newPostBox.Controls.Add(this.createUserButton);
            this.newPostBox.Controls.Add(this.label3);
            this.newPostBox.Location = new System.Drawing.Point(12, 151);
            this.newPostBox.Name = "newPostBox";
            this.newPostBox.Size = new System.Drawing.Size(189, 220);
            this.newPostBox.TabIndex = 1;
            this.newPostBox.TabStop = false;
            this.newPostBox.Text = "Create Post";
            this.newPostBox.Visible = false;
            // 
            // requestPostButton
            // 
            this.requestPostButton.Location = new System.Drawing.Point(6, 191);
            this.requestPostButton.Name = "requestPostButton";
            this.requestPostButton.Size = new System.Drawing.Size(167, 23);
            this.requestPostButton.TabIndex = 4;
            this.requestPostButton.Text = "Request Posts";
            this.requestPostButton.UseVisualStyleBackColor = true;
            this.requestPostButton.Click += new System.EventHandler(this.requestPostButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(76, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 412);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.newPostBox);
            this.Controls.Add(this.connectBox);
            this.MinimumSize = new System.Drawing.Size(557, 357);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.connectBox.ResumeLayout(false);
            this.connectBox.PerformLayout();
            this.newPostBox.ResumeLayout(false);
            this.newPostBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox connectBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.GroupBox newPostBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button requestPostButton;
    }
}