using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public struct Message
    {
        public string UserName;
        public string Data;
        public Message(string name, string message)
        {
            UserName = name;
            Data = message;
        }
    }
}
