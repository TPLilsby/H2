public enum MessageCarrier { Smtp, VMessage }

public class Message
{

    string to, from, body, subject, cc;

    public Message(string to, string from, string body, string subject, string cc)
    {
        this.to = to;
        this.from = from;
        this.body = body;
        this.subject = subject;
        this.cc = cc;
    }

    public string To { get => to; set => to = value; }
    public string From { get => from; set => from = value; }
    public string Body { get => body; set => body = value; }
    public string Subject { get => subject; set => subject = value; }
    public string Cc { get => cc; set => cc = value; }

    public void sendMessage(MessageCarrier type, Message m, bool isHTML)
    {
        //herinde sendes der en email ud til modtageren
        if (type.Equals(MessageCarrier.Smtp))
        {
            if (isHTML)
                m.Body = ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via Smtp
        }

        if (type.Equals(MessageCarrier.VMessage))
        {
            if (isHTML)
                m.Body = ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via VMessage
        }
    }


    public string ConvertBodyToHTML(string plainText)
    {
        return "" + plainText + "";
    }

    public void sendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML)
    {
        if (type.Equals(MessageCarrier.Smtp))
        {
            if (isHTML)
                m.Body = ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via Smtp
        }

        if (type.Equals(MessageCarrier.VMessage))
        {
            if (isHTML)
                m.Body = ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via VMessage
        }
    }
}