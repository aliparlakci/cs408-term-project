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
            this.postContentBox = new System.Windows.Forms.RichTextBox();
            this.sendPostButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.requestPostButton = new System.Windows.Forms.Button();
            this.deletePostBox = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deletePostInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.friends = new System.Windows.Forms.TabPage();
            this.addFriend = new System.Windows.Forms.Button();
            this.addFriendInput = new System.Windows.Forms.TextBox();
            this.removeFriendButton = new System.Windows.Forms.Button();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.posts = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Activate = new System.Windows.Forms.Button();
            this.activatePostInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.feed = new System.Windows.Forms.TabPage();
            this.archiveButton = new System.Windows.Forms.Button();
            this.myPostsButton = new System.Windows.Forms.Button();
            this.friendsPostsButton = new System.Windows.Forms.Button();
            this.connectBox.SuspendLayout();
            this.newPostBox.SuspendLayout();
            this.deletePostBox.SuspendLayout();
            this.friends.SuspendLayout();
            this.posts.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.logBox.Size = new System.Drawing.Size(606, 468);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(953, 486);
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
            this.newPostBox.Size = new System.Drawing.Size(384, 118);
            this.newPostBox.TabIndex = 1;
            this.newPostBox.TabStop = false;
            this.newPostBox.Text = "Create Post";
            // 
            // postContentBox
            // 
            this.postContentBox.Location = new System.Drawing.Point(76, 19);
            this.postContentBox.Name = "postContentBox";
            this.postContentBox.Size = new System.Drawing.Size(300, 55);
            this.postContentBox.TabIndex = 4;
            this.postContentBox.Text = "";
            // 
            // sendPostButton
            // 
            this.sendPostButton.Location = new System.Drawing.Point(292, 80);
            this.sendPostButton.Name = "sendPostButton";
            this.sendPostButton.Size = new System.Drawing.Size(84, 23);
            this.sendPostButton.TabIndex = 2;
            this.sendPostButton.Text = "Send Post";
            this.sendPostButton.UseVisualStyleBackColor = true;
            this.sendPostButton.Click += new System.EventHandler(this.sendPostButton_Click);
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
            // requestPostButton
            // 
            this.requestPostButton.Location = new System.Drawing.Point(23, 31);
            this.requestPostButton.Name = "requestPostButton";
            this.requestPostButton.Size = new System.Drawing.Size(350, 52);
            this.requestPostButton.TabIndex = 4;
            this.requestPostButton.Text = "All Posts";
            this.requestPostButton.UseVisualStyleBackColor = true;
            this.requestPostButton.Click += new System.EventHandler(this.requestPostButton_Click);
            // 
            // deletePostBox
            // 
            this.deletePostBox.Controls.Add(this.deleteButton);
            this.deletePostBox.Controls.Add(this.deletePostInput);
            this.deletePostBox.Controls.Add(this.label4);
            this.deletePostBox.Location = new System.Drawing.Point(6, 129);
            this.deletePostBox.Name = "deletePostBox";
            this.deletePostBox.Size = new System.Drawing.Size(384, 84);
            this.deletePostBox.TabIndex = 2;
            this.deletePostBox.TabStop = false;
            this.deletePostBox.Text = "Delete Post";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(292, 50);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deletePostInput
            // 
            this.deletePostInput.Location = new System.Drawing.Point(76, 23);
            this.deletePostInput.Name = "deletePostInput";
            this.deletePostInput.Size = new System.Drawing.Size(300, 20);
            this.deletePostInput.TabIndex = 1;
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
            // friends
            // 
            this.friends.Controls.Add(this.addFriend);
            this.friends.Controls.Add(this.addFriendInput);
            this.friends.Controls.Add(this.removeFriendButton);
            this.friends.Controls.Add(this.friendsListBox);
            this.friends.Location = new System.Drawing.Point(4, 22);
            this.friends.Name = "friends";
            this.friends.Padding = new System.Windows.Forms.Padding(3);
            this.friends.Size = new System.Drawing.Size(396, 303);
            this.friends.TabIndex = 1;
            this.friends.Text = "Friends";
            this.friends.UseVisualStyleBackColor = true;
            // 
            // addFriend
            // 
            this.addFriend.Location = new System.Drawing.Point(226, 63);
            this.addFriend.Name = "addFriend";
            this.addFriend.Size = new System.Drawing.Size(135, 23);
            this.addFriend.TabIndex = 3;
            this.addFriend.Text = "Add Friend";
            this.addFriend.UseVisualStyleBackColor = true;
            this.addFriend.Click += new System.EventHandler(this.addFriend_Click);
            // 
            // addFriendInput
            // 
            this.addFriendInput.Location = new System.Drawing.Point(226, 37);
            this.addFriendInput.Name = "addFriendInput";
            this.addFriendInput.Size = new System.Drawing.Size(135, 20);
            this.addFriendInput.TabIndex = 2;
            // 
            // removeFriendButton
            // 
            this.removeFriendButton.Location = new System.Drawing.Point(18, 229);
            this.removeFriendButton.Name = "removeFriendButton";
            this.removeFriendButton.Size = new System.Drawing.Size(162, 23);
            this.removeFriendButton.TabIndex = 1;
            this.removeFriendButton.Text = "Remove Friend";
            this.removeFriendButton.UseVisualStyleBackColor = true;
            this.removeFriendButton.Click += new System.EventHandler(this.removeFriendButton_Click);
            // 
            // friendsListBox
            // 
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.Location = new System.Drawing.Point(18, 37);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(162, 186);
            this.friendsListBox.TabIndex = 0;
            // 
            // posts
            // 
            this.posts.Controls.Add(this.groupBox1);
            this.posts.Controls.Add(this.deletePostBox);
            this.posts.Controls.Add(this.newPostBox);
            this.posts.Location = new System.Drawing.Point(4, 22);
            this.posts.Name = "posts";
            this.posts.Padding = new System.Windows.Forms.Padding(3);
            this.posts.Size = new System.Drawing.Size(396, 303);
            this.posts.TabIndex = 0;
            this.posts.Text = "Posts";
            this.posts.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Activate);
            this.groupBox1.Controls.Add(this.activatePostInput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(6, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activate Post";
            // 
            // Activate
            // 
            this.Activate.Location = new System.Drawing.Point(292, 50);
            this.Activate.Name = "Activate";
            this.Activate.Size = new System.Drawing.Size(84, 23);
            this.Activate.TabIndex = 2;
            this.Activate.Text = "Activate";
            this.Activate.UseVisualStyleBackColor = true;
            this.Activate.Click += new System.EventHandler(this.Activate_Click);
            // 
            // activatePostInput
            // 
            this.activatePostInput.Location = new System.Drawing.Point(76, 23);
            this.activatePostInput.Name = "activatePostInput";
            this.activatePostInput.Size = new System.Drawing.Size(300, 20);
            this.activatePostInput.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Post ID";
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
            this.tabControl1.Size = new System.Drawing.Size(404, 329);
            this.tabControl1.TabIndex = 4;
            // 
            // feed
            // 
            this.feed.Controls.Add(this.archiveButton);
            this.feed.Controls.Add(this.myPostsButton);
            this.feed.Controls.Add(this.friendsPostsButton);
            this.feed.Controls.Add(this.requestPostButton);
            this.feed.Location = new System.Drawing.Point(4, 22);
            this.feed.Name = "feed";
            this.feed.Size = new System.Drawing.Size(396, 303);
            this.feed.TabIndex = 2;
            this.feed.Text = "Feed";
            this.feed.UseVisualStyleBackColor = true;
            // 
            // archiveButton
            // 
            this.archiveButton.Location = new System.Drawing.Point(23, 205);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(350, 52);
            this.archiveButton.TabIndex = 7;
            this.archiveButton.Text = "My Archive";
            this.archiveButton.UseVisualStyleBackColor = true;
            this.archiveButton.Click += new System.EventHandler(this.archiveButton_Click);
            // 
            // myPostsButton
            // 
            this.myPostsButton.Location = new System.Drawing.Point(23, 147);
            this.myPostsButton.Name = "myPostsButton";
            this.myPostsButton.Size = new System.Drawing.Size(350, 52);
            this.myPostsButton.TabIndex = 6;
            this.myPostsButton.Text = "My Posts";
            this.myPostsButton.UseVisualStyleBackColor = true;
            this.myPostsButton.Click += new System.EventHandler(this.myPostsButton_Click);
            // 
            // friendsPostsButton
            // 
            this.friendsPostsButton.Location = new System.Drawing.Point(23, 89);
            this.friendsPostsButton.Name = "friendsPostsButton";
            this.friendsPostsButton.Size = new System.Drawing.Size(350, 52);
            this.friendsPostsButton.TabIndex = 5;
            this.friendsPostsButton.Text = "Friends\' Posts";
            this.friendsPostsButton.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 521);
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
            this.friends.ResumeLayout(false);
            this.friends.PerformLayout();
            this.posts.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox deletePostInput;
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
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Activate;
        private System.Windows.Forms.TextBox activatePostInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button removeFriendButton;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Button addFriend;
        private System.Windows.Forms.TextBox addFriendInput;
    }
}