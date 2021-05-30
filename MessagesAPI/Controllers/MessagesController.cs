using MessagesAPI.DAL;
using MessagesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessagesAPI.Controllers
{
    public class MessagesController : ApiController
    {

        [HttpGet]
        [Route("api/Messages/GetMessages/{id}")]
        public List<Message> GetMessages(string id)
        {
            MessagesDAL messagesDAL = new MessagesDAL();
            List<Message> messages = messagesDAL.GetAllMessages(id);
            return messages;
        }


        [HttpGet]
        [Route("api/Messages/GetUnReadMessages/{id}")]
        public List<Message> GetUnReadMessages(string id)
        {
            MessagesDAL messagesDAL = new MessagesDAL();
            List<Message> messages = messagesDAL.GetAllUnReadMessages(id);
            return messages;
        }

        [HttpGet]
        [Route("api/Messages/GetMessage/{id}")]
        public List<Message> GetMessage(string id)
        {
            MessagesDAL messagesDAL = new MessagesDAL();
            List<Message> messages = messagesDAL.ReadMessage(id);
            return messages;
        }


        [HttpGet]
        [Route("api/Messages/WriteMessages/{id}")]
        public List<Message> WriteMessages(string id)
        {
            MessagesDAL messagesDAL = new MessagesDAL();
            List<Message> messages = messagesDAL.WriteMessage(id);
            return messages;
        }


        [HttpGet]
        [Route("api/Messages/DeleteMessage/{id}")]
        public List<Message> DeleteMessage(string id, string id1)
        {
            MessagesDAL messagesDAL = new MessagesDAL();
            List<Message> messages = messagesDAL.DeleteMessage(id, id1);
            return messages;
        }



    }
}
