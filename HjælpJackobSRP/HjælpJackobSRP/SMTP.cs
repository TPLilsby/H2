using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpJackobSRP
{
    public class SMTPMessageHandler : IMessageHandler
    {
        public void SendMessage(Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via Smtp
        }
        public void SendMessageToAll(string[] to, Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via Smtp
        }
    }
}
