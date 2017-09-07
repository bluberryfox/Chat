using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interface
{
    class Connection
    {
        private Socket serverSocket;
        private Thread clientThread;
        public string ServerHost;
        private int serverPort;
        public delegate void ReceiveUsersStateHandler(object sender, DataEventArgs e);
        public event ReceiveUsersStateHandler ReceivingUsers;
        public delegate void ReceiveMessagesStateHandler(object sender, DataEventArgs e);
        public event ReceiveMessagesStateHandler ReceivingMessages;
        public event EventHandler OnDisconnect;




        public Connection(string serverHost, int serverPort)
        {
            this.ServerHost = serverHost;
            this.serverPort = serverPort;

        }
        private void parseUser(string data)
        {
            string temp = data.Substring(12);
            string[] users = temp.Split('&');
            if (ReceivingUsers != null)
            {
                ReceivingUsers(this, new DataEventArgs(users));

            }
        }
        private void parseMessage(string data)
        {
            try {
                string[] temp = data.Split('&')[1].Split('|');

                int countMessages = temp.Length;
                string[] msg = new string[countMessages];
                if (countMessages <= 0) return;
                for (int i = 0; i < countMessages; i++)
                {
                    if (string.IsNullOrEmpty(temp[i])) continue;
                    msg[i] = String.Format("[{0}]:{1}.", temp[i].Split('~')[0], temp[i].Split('~')[1]);

                }
                if (msg[0] == null)
                    msg[0] = "";
                if (ReceivingUsers != null)
                {
                    ReceivingMessages(this, new DataEventArgs(msg));

                }
            } catch (IndexOutOfRangeException)
            {
                
            }
        }

        
        private void listner()
        {

            while (serverSocket.Connected)
            {


                byte[] buffer = new byte[8196];
                int bytesRec;
                try
                {
                    bytesRec = serverSocket.Receive(buffer);
                }
                catch (SocketException)
                {
                    Disconnect();
                    return;
                }
                string[] data = Encoding.UTF8.GetString(buffer, 0, bytesRec).Split('\n');
                for (int i = 0; i < data.Length - 1; i++)
                    if (data[i].Contains("#updatechat"))
                    {
                        parseMessage(data[i]);

                    }
                    else if (data[i].Contains("#updateuser"))
                    {
                        parseUser(data[i]);
                    }

            }

        }

        public void Connect()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ServerHost);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
                clientThread = new Thread(listner);
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            catch(SocketException)
            {
                serverSocket = null;
            }
        }
        public void Send(string data)
        {
            try
            {
                
                byte[] buffer = Encoding.UTF8.GetBytes(data + '\n');
                int bytesSent = serverSocket.Send(buffer);

            }
            catch(SocketException)
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            clientThread.Interrupt();
            try
            {
                serverSocket.Close();
            }
            catch
            {
            }
            serverSocket = null;
            OnDisconnect?.Invoke(null, null);
        }
    }
}
