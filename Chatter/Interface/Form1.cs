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
        private Socket serverSocket;
        private Thread clientThread;
        private const string serverHost = "localhost";
        private const int serverPort = 9933;
        public ChatForm()
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);
            connect();
            clientThread = new Thread(listner);
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        private void listner()
        {
            while (serverSocket.Connected)
            {
                Thread.Sleep(10);
                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("updatechat"))
                {
                    updateChat(data);
                    continue;
                }
                if (data.Contains("#updateuser"))
                {
                    updateOnline(data);
                }


            }
        }

        private void updateOnline(string data)
        {
            clearChat(onlineVisitors);
            string temp = data.Substring(12);
            string[] users = temp.Split('&');
            for (int i = 0; i < users.Length - 1; i++)
            {

                print(users[i], onlineVisitors);
            }


        }

        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
            }
            catch { print("Сервер недоступен!", chatBox); }
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
        private void updateChat(string data)
        {
            clearChat(chatBox);
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]), chatBox);
                }
                catch
                {
                    continue;
                }
            }
        }

        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);
            }
            catch { print("Связь с сервером прервалась...", chatBox); }
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
            string n = userName.Text;
            if (string.IsNullOrEmpty(n)) return;
            name = n;
            send("#setname&" + name);
            send("#updateusers" + name);
            chatBox.Enabled = true;
            chat_msg.Enabled = true;
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
                send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
                send("#updateusers" + name);
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }
    }
}
