using DataTransferGraph2;

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
            using (var context = new DatabaseModelContext(DatabaseOperations.Path))
            {
                context.Messages.Add(databaseMessage);
                context.SaveChanges();
            }
        }
    }
}
