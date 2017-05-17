using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class DataEventArgs:EventArgs
    {
        public string Data;
        public DataEventArgs(string data)
        {
            Data = data;
        }
    }
}
