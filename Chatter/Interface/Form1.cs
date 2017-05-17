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
        printer Printer;
        cleaner Cleaner;
        Connection connection;

        public ChatForm()
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);
            connection = new Connection("localhost", 9933);

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
            string [] messages = e.Data;
            clearChat(chatBox);
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

        private void enterChat_Click(object sender, EventArgs e)
        {

            connection.ReceivingUsers += updateOnline;
            connection.ReceivingMessages += updateChat;
            string temp = userName.Text;
            if (string.IsNullOrEmpty(temp)) return;
            name = temp;

            connection.Send("#setname&" + name);
            connection.Send("#updateusers" + name);
            chatBox.Enabled = true;
            chat_msg.Enabled = true;

            onlineVisitors.Enabled = true;
            chat_send.Enabled = true;
            userName.Enabled = false;
            enterChat.Enabled = false;

        }

        private void chat_send_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void sendMessage()
        {
            try
            {
                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                connection.Send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
            }
            catch(SocketException e) { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

    }
}

