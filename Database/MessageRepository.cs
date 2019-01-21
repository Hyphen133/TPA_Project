using DataTransferGraph2;
using System.Configuration;

namespace Database
{
    public class MessageRepository
    {
        public void AddMessage(DTGMessage dTGMessage)
        {
            DatabaseMessage databaseMessage = new DatabaseMessage
            {
                MessageString = dTGMessage.MessageString
            };
            using (var context = new DatabaseModelContext(ConfigurationManager.AppSettings["connectionstring"]))
            {
                context.Messages.Add(databaseMessage);
                context.SaveChanges();
            }
        }
    }
}
