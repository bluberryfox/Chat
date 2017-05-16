using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public static class ChatController
    {

        public static List<Message> Chat = new List<Message>();

        public static void AddMessage(string userName, string message)
        {
            try
            {
                if ((userName == null) || (message == null))
                {
                    return;
                }
                Message newMessage = new Message(userName, message);
                Chat.Add(newMessage);
                Console.WriteLine("New message from " + userName);
                Server.UpdateAllChats();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with addMessage: " + e.Message);
            }
        }

        public static string GetChat()
        {
            try
            {
                string data = "#updatechat&";
                int countMessages = Chat.Count;
                if (countMessages <= 0) return String.Empty;
                for (int i = 0; i < countMessages; i++)
                {
                    data += Chat[i].UserName + "~" + Chat[i].Data + "|";
                }
                return data;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error with getChat: " + exp.Message);
                return null;
            }
        }
        public static string GetUser()
        {
            try
            {
                string data = "#updateuser&";
                for (int i = 0; i < Server.Clients.Count; i++)
                {
                    data += Server.Clients[i].UserName;
                }
                return data;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error with getUser: " + exp.Message);
                return null;
            }
        }
    }
}

