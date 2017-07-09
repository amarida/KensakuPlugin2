using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Plugin;

namespace Tekidoni
{
	public partial class MessageForm : Form
	{
		IPluginHost host;

		public MessageForm(IPluginHost host)
		{
			this.host = host;

			InitializeComponent();
		}

		private void sendButton_Click(object sender, EventArgs e)
		{
			if (messageTextBox.Text == string.Empty)
			{
				return;
			}
			PostMessage(messageTextBox.Text, nameTextBox.Text, commandTextBox.Text);
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			messageTextBox.Text = string.Empty;
		}

		private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				return;
			}
			e.SuppressKeyPress = true;
			PostMessage(messageTextBox.Text, nameTextBox.Text, commandTextBox.Text);
			messageTextBox.Text = string.Empty;
		}

		private void PostMessage(string message, string name, string command)
		{
			if (message == string.Empty)
			{
				return;
			}
			Utility.PostMessageOwner(host, message, name, command);
		}
	}
}
