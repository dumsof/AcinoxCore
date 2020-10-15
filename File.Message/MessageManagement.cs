namespace File.Message
{
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageManagement : IMessageManagement
    {
        private readonly IOptions<List<Message>> optionMessage;

        public MessageManagement(IOptions<List<Message>> optionMessage)
        {
            this.optionMessage = optionMessage;
        }

        public string GetMessage(MessageType messageTypeEnum)
        {
            var message = string.Empty;

            message = this.optionMessage.Value.Where(c => c.CodeMessage == (int)messageTypeEnum).FirstOrDefault().DescriptionMessage;

            return message;
        }

        public string GetMessage(MessageType messageTypeEnum, params object[] value)
        {
            var message = string.Empty;

            message = this.optionMessage.Value.Where(c => c.CodeMessage == (int)messageTypeEnum).FirstOrDefault().DescriptionMessage;

            if (message != null && value != null)
            {
                message = string.Format(message, value);
            }

            return message;
        }
    }
}