
using System;

namespace MessagesAPI.Entities
{
    [Serializable]
    public class Message
    {
        public Message(int idMessage, string sender, string reciver, string messageContent, string subject, DateTime creatrionDate)
        {
            this.IdMessage = idMessage;
            this.Sender = sender;
            this.Reciver = reciver;
            this.MessageContent = messageContent;
            this.Subject = subject;
            this.CreatrionDate = creatrionDate;
        }

        public int IdMessage { get; }
        public string Sender { get; }
        public string Reciver { get; }
        public string MessageContent { get; }
        public string Subject { get; }
        public DateTime CreatrionDate { get; }


    }
}