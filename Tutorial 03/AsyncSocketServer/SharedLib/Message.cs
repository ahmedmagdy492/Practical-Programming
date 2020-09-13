using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public class Message
    {
        public readonly Dictionary<string, string> Headers;

        public Message()
        {
            Headers = new Dictionary<string, string>();
        }
    }
}
