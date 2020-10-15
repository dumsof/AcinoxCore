namespace File.Message
{
    public interface IMessageManagement
    {
        string GetMessage(MessageType messageTypeEnum);

        string GetMessage(MessageType messageTypeEnum, params object[] value);
    }
}