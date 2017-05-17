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
        private string serverHost;
        private int serverPort;
        public delegate void ReceiveUsersStateHandler(object sender, DataEventArgs e);
        public event ReceiveUsersStateHandler ReceivingUsers;
        public delegate void ReceiveMessagesStateHandler(object sender, DataEventArgs e);
        public event ReceiveMessagesStateHandler ReceivingMessages;




        public Connection(string serverHost, int serverPort)
        {
            this.serverHost = serverHost;
            this.serverPort = serverPort;
            connect();
            clientThread = new Thread(listner);
            clientThread.IsBackground = true;
            clientThread.Start();

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
                if (ReceivingUsers != null)
                {
                    ReceivingMessages(this, new DataEventArgs(msg));

                }
            } catch (IndexOutOfRangeException e)
            {
                
            }
        }

        
        private void listner()
        {

            while (serverSocket.Connected)
            {


                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#updatechat"))
                {
                    parseMessage(data);

                }
                if (data.Contains("#updateuser"))
                {
                    parseUser(data);
                }

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
            catch(SocketException e)
            {
                
            }
        }
        public void Send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);

            }
            catch(SocketException e)
            {
                
            }
        }
    }
}
