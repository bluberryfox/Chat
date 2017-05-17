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
        private const string serverHost = "localhost";
        private const int serverPort = 9933;
        public delegate void ReceiveStateHandler(object sender, DataEventArgs e);
        public event ReceiveStateHandler ReceivingData;



        public Connection()
        {
            Connect();
            clientThread = new Thread(listner);
            clientThread.IsBackground = true;
            clientThread.Start();
        }
        public void listner()
        {
           
            while (serverSocket.Connected) { 
                Thread.Sleep(10);
            
                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (ReceivingData != null)
                {
                    ReceivingData(this, new DataEventArgs(data));
                }
            }

        }
        
        public void Connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
            }
            catch
            {
                // ChatForm.print("Сервер недоступен!", chatBox);
            }
        }
        public void Send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);
            }
            catch {
                //print("Связь с сервером прервалась...", chatBox);
            }
        }
    }
}
