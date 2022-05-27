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
            this.label5 = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.newPostBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendPostButton = new System.Windows.Forms.Button();
            this.postContentBox = new System.Windows.Forms.RichTextBox();
            this.requestPostButton = new System.Windows.Forms.Button();
            this.deletePostBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.friends = new System.Windows.Forms.TabPage();
            this.posts = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.feed = new System.Windows.Forms.TabPage();
            this.friendsPostsButton = new System.Windows.Forms.Button();
            this.myPostsButton = new System.Windows.Forms.Button();
            this.connectBox.SuspendLayout();
            this.newPostBox.SuspendLayout();
            this.deletePostBox.SuspendLayout();
            this.posts.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.feed.SuspendLayout();
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
            this.connectBox.Size = new System.Drawing.Size(193, 133);
            this.connectBox.TabIndex = 0;
            this.connectBox.TabStop = false;
            this.connectBox.Text = "Connect";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(9, 97);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(175, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(76, 45);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(108, 20);
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
            this.ipInput.Size = new System.Drawing.Size(108, 20);
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
            this.userNameInput.Size = new System.Drawing.Size(108, 20);
            this.userNameInput.TabIndex = 3;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(422, 12);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(530, 432);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(877, 450);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // newPostBox
            // 
            this.newPostBox.Controls.Add(this.postContentBox);
            this.newPostBox.Controls.Add(this.sendPostButton);
            this.newPostBox.Controls.Add(this.label3);
            this.newPostBox.Location = new System.Drawing.Point(6, 6);
            this.newPostBox.Name = "newPostBox";
            this.newPostBox.Size = new System.Drawing.Size(384, 154);
            this.newPostBox.TabIndex = 1;
            this.newPostBox.TabStop = false;
            this.newPostBox.Text = "Create Post";
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
            // sendPostButton
            // 
            this.sendPostButton.Location = new System.Drawing.Point(292, 121);
            this.sendPostButton.Name = "sendPostButton";
            this.sendPostButton.Size = new System.Drawing.Size(84, 23);
            this.sendPostButton.TabIndex = 2;
            this.sendPostButton.Text = "Send Post";
            this.sendPostButton.UseVisualStyleBackColor = true;
            this.sendPostButton.Click += new System.EventHandler(this.sendPostButton_Click);
            // 
            // postContentBox
            // 
            this.postContentBox.Location = new System.Drawing.Point(76, 19);
            this.postContentBox.Name = "postContentBox";
            this.postContentBox.Size = new System.Drawing.Size(300, 96);
            this.postContentBox.TabIndex = 4;
            this.postContentBox.Text = "";
            // 
            // requestPostButton
            // 
            this.requestPostButton.Location = new System.Drawing.Point(16, 18);
            this.requestPostButton.Name = "requestPostButton";
            this.requestPostButton.Size = new System.Drawing.Size(114, 23);
            this.requestPostButton.TabIndex = 4;
            this.requestPostButton.Text = "All Posts";
            this.requestPostButton.UseVisualStyleBackColor = true;
            this.requestPostButton.Click += new System.EventHandler(this.requestPostButton_Click);
            // 
            // deletePostBox
            // 
            this.deletePostBox.Controls.Add(this.deleteButton);
            this.deletePostBox.Controls.Add(this.textBox1);
            this.deletePostBox.Controls.Add(this.label4);
            this.deletePostBox.Location = new System.Drawing.Point(6, 166);
            this.deletePostBox.Name = "deletePostBox";
            this.deletePostBox.Size = new System.Drawing.Size(384, 84);
            this.deletePostBox.TabIndex = 2;
            this.deletePostBox.TabStop = false;
            this.deletePostBox.Text = "Delete Post";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Post ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 20);
            this.textBox1.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(292, 50);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // friends
            // 
            this.friends.Location = new System.Drawing.Point(4, 22);
            this.friends.Name = "friends";
            this.friends.Padding = new System.Windows.Forms.Padding(3);
            this.friends.Size = new System.Drawing.Size(396, 267);
            this.friends.TabIndex = 1;
            this.friends.Text = "Friends";
            this.friends.UseVisualStyleBackColor = true;
            // 
            // posts
            // 
            this.posts.Controls.Add(this.deletePostBox);
            this.posts.Controls.Add(this.newPostBox);
            this.posts.Location = new System.Drawing.Point(4, 22);
            this.posts.Name = "posts";
            this.posts.Padding = new System.Windows.Forms.Padding(3);
            this.posts.Size = new System.Drawing.Size(396, 267);
            this.posts.TabIndex = 0;
            this.posts.Text = "Posts";
            this.posts.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.feed);
            this.tabControl1.Controls.Add(this.posts);
            this.tabControl1.Controls.Add(this.friends);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 293);
            this.tabControl1.TabIndex = 4;
            // 
            // feed
            // 
            this.feed.Controls.Add(this.myPostsButton);
            this.feed.Controls.Add(this.friendsPostsButton);
            this.feed.Controls.Add(this.requestPostButton);
            this.feed.Location = new System.Drawing.Point(4, 22);
            this.feed.Name = "feed";
            this.feed.Size = new System.Drawing.Size(396, 267);
            this.feed.TabIndex = 2;
            this.feed.Text = "Feed";
            this.feed.UseVisualStyleBackColor = true;
            // 
            // friendsPostsButton
            // 
            this.friendsPostsButton.Location = new System.Drawing.Point(136, 18);
            this.friendsPostsButton.Name = "friendsPostsButton";
            this.friendsPostsButton.Size = new System.Drawing.Size(114, 23);
            this.friendsPostsButton.TabIndex = 5;
            this.friendsPostsButton.Text = "Friends\' Posts";
            this.friendsPostsButton.UseVisualStyleBackColor = true;
            // 
            // myPostsButton
            // 
            this.myPostsButton.Location = new System.Drawing.Point(256, 18);
            this.myPostsButton.Name = "myPostsButton";
            this.myPostsButton.Size = new System.Drawing.Size(114, 23);
            this.myPostsButton.TabIndex = 6;
            this.myPostsButton.Text = "My Posts";
            this.myPostsButton.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.connectBox);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 357);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.connectBox.ResumeLayout(false);
            this.connectBox.PerformLayout();
            this.newPostBox.ResumeLayout(false);
            this.newPostBox.PerformLayout();
            this.deletePostBox.ResumeLayout(false);
            this.deletePostBox.PerformLayout();
            this.posts.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.feed.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox deletePostBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox newPostBox;
        private System.Windows.Forms.Button requestPostButton;
        private System.Windows.Forms.RichTextBox postContentBox;
        private System.Windows.Forms.Button sendPostButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage friends;
        private System.Windows.Forms.TabPage posts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage feed;
        private System.Windows.Forms.Button myPostsButton;
        private System.Windows.Forms.Button friendsPostsButton;
    }
}