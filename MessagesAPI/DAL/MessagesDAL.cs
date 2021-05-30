using MessagesAPI.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MessagesAPI.DAL
{
    public class MessagesDAL
    {
        public MessagesDAL()
        {

        }

        public List<Message> GetAllMessages(string reciver)
        {
            List<Message> messages = new List<Message>();

            string connectionString = @"server=localhost;userid=root;password=1234;database=sys";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var query = $"select * from sys.messages where reciver = '{reciver}'";
                var cmd = new MySqlCommand(query, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Message message =
                            new Message(rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4),
                            rdr.GetDateTime(5));
                        messages.Add(message);
                    }
                }
            }

            return messages;
        }


        public List<Message> GetAllUnReadMessages(string reciver)
        {
            List<Message> messages = new List<Message>();

            string connectionString = @"server=localhost;userid=root;password=1234;database=sys";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var query = $"select * from sys.messages where reciver = '{reciver}' and isread = false";
                var cmd = new MySqlCommand(query, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Message message =
                            new Message(rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4),
                            rdr.GetDateTime(5));
                        messages.Add(message);
                    }
                }
            }

            return messages;
        }

        public List<Message> ReadMessage(string reciver)
        {
            List<Message> messages = new List<Message>();

            string connectionString = @"server=localhost;userid=root;password=1234;database=sys";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var query = $"select * from sys.messages where reciver = '{reciver}' order by creatrionDate desc LIMIT 1";
                var cmd = new MySqlCommand(query, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Message message =
                            new Message(rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4),
                            rdr.GetDateTime(5));
                        messages.Add(message);
                    }
                }

                var update = $"update sys.messages a set a.isRead = true where idMe = '{reciver}' ";
                var cmdUpdate = new MySqlCommand(update, con);
                cmdUpdate.ExecuteNonQuery();



            }

            return messages;
        }


        public List<Message> WriteMessage(string seder)
        {
            List<Message> messages = new List<Message>();

            string connectionString = @"server=localhost;userid=root;password=1234;database=sys";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var query = $"insert into sys.message values(sende,reciver,messageContent,subject,creatrionDate,isRead)";
                var cmd = new MySqlCommand(query, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Message message =
                            new Message(rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4),
                            rdr.GetDateTime(5));
                        messages.Add(message);
                    }
                }
            }

            return messages;
        }


        public List<Message> DeleteMessage(string sender, string reciver)
        {
            List<Message> messages = new List<Message>();

            string connectionString = @"server=localhost;userid=root;password=1234;database=sys";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var query = $"delete from sys.message where sender= '{sender}' or reciver= '{reciver}'";
                var cmd = new MySqlCommand(query, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Message message =
                            new Message(rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4),
                            rdr.GetDateTime(5));
                        messages.Add(message);
                    }
                }
            }

            return messages;
        }

    }
}