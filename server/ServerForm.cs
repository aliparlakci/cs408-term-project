using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class ServerForm : Form
    {
        private Server _server;
        private Logger _logger;

        public ServerForm(Server server, Logger logger)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _server = server;
            _logger = logger;

            InitializeComponent();

            _logger.SetWriter(logBox.AppendText);
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(portInput.Text, out serverPort))
            {
                if (_server.Listen(serverPort))
                {
                    listenButton.Enabled = false;
                    portInput.Enabled = false;
                    logBox.Enabled = true;

                    _logger.Write($"Started listening on port: {serverPort}\n");
                }
                else
                {
                    _logger.Write("Cannot start listening.\n");
                }
            }
            else
            {
                _logger.Write("Check the port number!\n");
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Dispose();
            Environment.Exit(0);
        }
    }
}
