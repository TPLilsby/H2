using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpJackobSRP
{
    public interface IMessageHandler
    {
        void SendMessage(Message m, bool isHTML);
        void SendMessageToAll(string[] to, Message m, bool isHTML);
    }
}
