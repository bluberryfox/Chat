using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class ChatForm : Form
    {
        private string name;
        private delegate void printer(string data, TextBox textBox);
        private delegate void cleaner(TextBox textBox);
        private delegate void enabler(Control o, bool enabled);
        printer Printer;
        cleaner Cleaner;
        enabler Enabler;
        Connection connection;

        public ChatForm()
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);
            Enabler = new enabler(toggleObj);
            connection = new Connection("", 9933);
            connection.ReceivingUsers += updateOnline;
            connection.ReceivingMessages += updateChat;
            connection.OnDisconnect += onDisconnect;
        }
        

        private void updateOnline(object sender, DataEventArgs e)
        {
            string[] users = e.Data; 
            clearChat(onlineVisitors);
            for (int i = 0; i < users.Length - 1; i++)
            {
                print(users[i], onlineVisitors);
            }
        }

        private void clearChat(TextBox textBox)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner, textBox);
                return;
            }
            textBox.Clear();
        }
        private void updateChat(object sender, DataEventArgs e)
        {
            clearChat(chatBox);
            string [] messages = e.Data;
            int countMessages = messages.Length;
            for (int i = 0; i < countMessages; i++)
            {
                print(messages[i], chatBox);
            }
        }

        private void print(string msg, TextBox textBox)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg, textBox);
                return;
            }
            if (textBox.Text.Length == 0)
                textBox.AppendText(msg);
            else
                textBox.AppendText(Environment.NewLine + msg);
        }

        private void toggleObj(Control o, bool enabled)
        {
            o.Enabled = enabled;
        }

        private void enterChat_Click(object sender, EventArgs e)
        {
            string temp = userName.Text;
            if (string.IsNullOrEmpty(temp)) return;

            connection.ServerHost = textBoxIP.Text;
            connection.Connect();
            name = temp;

            connection.Send("#setname&" + name);
            connection.Send("#updateusers" + name);
            chatBox.Enabled = true;
            chatMsg.Enabled = true;

            onlineVisitors.Enabled = true;
            chatSend.Enabled = true;
            userName.Enabled = false;
            enterChat.Enabled = false;
            buttonDisconnect.Enabled = true;
        }

        private void onDisconnect(object sender, EventArgs e)
        {
            clearChat(chatBox);
            clearChat(onlineVisitors);

            this.Invoke(Enabler, chatBox, false);
            this.Invoke(Enabler, chatMsg, false);

            this.Invoke(Enabler, onlineVisitors, false);
            this.Invoke(Enabler, buttonDisconnect, false);
            this.Invoke(Enabler, chatSend, false);
            this.Invoke(Enabler, userName, true);
            this.Invoke(Enabler, enterChat, true);
        }

        private void chatSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void sendMessage()
        {
            try
            {
                string data = chatMsg.Text;
                if (string.IsNullOrEmpty(data)) return;
                connection.Send("#newmsg&" + data);
                chatMsg.Text = string.Empty;
            }
            catch(SocketException e) { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }

        private void chatMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
      
        }

        private void buttonIgnore_Click(object sender, EventArgs e)
        {
            connection.Send("#blacklist&" + textBoxIgnore.Text);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            connection.Disconnect();
        }
    }
}

