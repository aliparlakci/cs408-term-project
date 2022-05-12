﻿using System;
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
                newUserBox.Visible = false;
                disconnectButton.Enabled = false;
            });

            _client.OnUsernameAlreadyExists(() =>
            {
                userNameInput.Text = "";
            });

            _client.OnSuccessfulAccountCreation(ClearInputs);
        }

        private void ClearInputs()
        {
            nameInput.Clear();
            surnameInput.Clear();
            userNameInput.Clear();
            passwordInput.Clear();
        }

        private bool VerifyInputs()
        {
            bool flag = true;

            if (nameInput.Text == "")
            {
                _logger.Write("Please enter a name\n");
                flag = false;
            }

            if (surnameInput.Text == "")
            {
                _logger.Write("Please enter a surname\n");
                flag = false;
            }

            if (userNameInput.Text == "")
            {
                _logger.Write("Please enter a username\n");
                flag = false;
            }

            if (passwordInput.Text == "")
            {
                _logger.Write("Please enter a password\n");
                flag = false;
            }

            return flag;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectBox.Enabled = false;

            string ip = ipInput.Text;
            int serverPort;

            if (Int32.TryParse(portInput.Text, out serverPort))
            {
                if (_client.Connect(ip.Trim(), serverPort))
                {
                    logBox.Enabled = true;

                    _logger.Write($"You are connected!\n");

                    newUserBox.Visible = true;
                    disconnectButton.Enabled = true;
                }
                else
                {
                    _logger.Write("Connection could not be established.\n");
                    connectBox.Enabled = true;
                }
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

        private void createUserButton_Click(object sender, EventArgs e)
        {
            if (!VerifyInputs())
            {
                return;
            }

            var message = CayGetirProtocol.Signup(nameInput.Text, surnameInput.Text, userNameInput.Text, passwordInput.Text);
            _client.Send(message);
        }
    }
}
