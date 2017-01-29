namespace PhantomNet.MessageSender
{
    public interface IMessageTemplateResolver
    {
        string ResolveTemplate(string location, string templateName);
    }
}
