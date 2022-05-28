using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class ClientForm : Form
    {
        private Client _client;
        private Logger _logger;

        public ClientForm(Client client, Logger logger)
        {
            _client = client;
            _logger = logger;

            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            _logger.SetWriter(logBox.AppendText);

            _client.OnDisconnect(() =>
            {
                connectBox.Enabled = true;
                tabControl1.Enabled = false;
                disconnectButton.Enabled = false;
            });

            _client.OnUsernameAlreadyExists(() =>
            {
                userNameInput.Text = "";
            });

            _client.OnSuccessfulAccountCreation(ClearInputs);

            _client.OnConnect(() =>
            {
                connectBox.Enabled = false;
                disconnectButton.Enabled = true;
                tabControl1.Enabled = true;
            });

            _client.OnUsernameNotExists(() =>
            {
                userNameInput.Text = "";
                connectBox.Enabled = true;
                tabControl1.Enabled = false;
            });

            _client.OnSendNewPost(() =>
            {
                postContentBox.Text = "";
            });

            _client.OnSetFriends(friends =>
            {
                friendsListBox.Items.Clear();
                foreach (var friend in friends)
                {
                    friendsListBox.Items.Add(friend);
                }
            });
        }

        private void ClearInputs()
        {
            userNameInput.Clear();
        }

        private bool VerifyInputs()
        {
            bool flag = true;

            if (userNameInput.Text == "")
            {
                _logger.Write("Please enter a username\n");
                flag = false;
            }

            return flag;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectBox.Enabled = false;

            string ip = ipInput.Text;
            int serverPort;

            if (ip == "")
            {
                _logger.Write("IP cannot be empty!\n");
                connectBox.Enabled = true;
                return;
            }

            if (Int32.TryParse(portInput.Text, out serverPort))
            {
                _client.Connect(ip.Trim(), serverPort, userNameInput.Text);
            }
            else
            {
                _logger.Write("Check the port number!\n");
                connectBox.Enabled = true;
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            _client.SetTerminating();
            _client.Disconnect();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void requestPostButton_Click(object sender, EventArgs e)
        {
            _client.RequestPosts();
        }

        private void sendPostButton_Click(object sender, EventArgs e)
        {
            _client.SendNewPost(postContentBox.Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(deletePostInput.Text, out id))
            {
                _client.DeletePost(id);
                deletePostInput.Text = "";
            }
            else
            {
                _logger.Write("Post ID must be integer!\n");
           
            }
        }

        private void myPostsButton_Click(object sender, EventArgs e)
        {
            _client.RequestMyPosts();
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            _client.RequestMyArchive();
        }

        private void Activate_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(activatePostInput.Text, out id))
            {
                _client.ActivatePost(id);
                activatePostInput.Text = "";
            }
            else
            {
                _logger.Write("Post ID must be integer!\n");

            }
        }

        private void removeFriendButton_Click(object sender, EventArgs e)
        {
            if(friendsListBox.SelectedItem != null)
            {
                _client.RemoveFriend(friendsListBox.SelectedItem.ToString());
            }
        }

        private void addFriend_Click(object sender, EventArgs e)
        {
            _client.AddFriend(addFriendInput.Text);
            addFriendInput.Text = "";
        }

        private void friendsPostsButton_Click(object sender, EventArgs e)
        {
            _client.RequestFriendsPosts();
        }
    }
}
