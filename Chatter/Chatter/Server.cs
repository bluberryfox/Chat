using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
   public static class Server
    {
        public static List<Client> Clients = new List<Client>();
        public static void NewClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                
        
                Console.WriteLine("New client connected: "+ handle.RemoteEndPoint);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error with addNewClient: "+ exp.Message);
            }
           
        }
        public static void DisconnectClient(Client client)
        {
            try
            {
                client.Disconnect();
                Clients.Remove(client);
                UpdateAllChats();
                Console.WriteLine("User " + client.UserName + " has been disconnected");

            }
            catch (Exception exp)
            {
                Console.WriteLine("Error with endClient: "+ exp.Message);
            }
        }
        public static void UpdateAllChats()
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Clients[i].UpdateChat();
                    Clients[i].UpdateUser();
                }
            }
            catch (Exception exp) { Console.WriteLine("Error with updateAlLChats: "+ exp.Message); }
        }
        //public static void UpdateAllUsers()
        //{
        //    try
        //    {
        //        for (int i = 0; i <Clients.Count; i++)
        //        {
                    
        //        }
        //    }
        //    catch (Exception exp) { Console.WriteLine("Error with updateAllUsers: " + exp.Message); }
        //}
        //public static void Update(Delegate deleg)
        //{
        //    try
        //    {
        //        for (int i = 0; i < Clients.Count; i++)
        //        {
        //            Clients[i].deleg;
        //        }
        //    }
        //    catch (Exception exp) { Console.WriteLine("Error with updateAllUsers: " + exp.Message); }
        //}
       

    }
}
