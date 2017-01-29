namespace PhantomNet.MessageSenders
{
    public interface IMessageTemplateResolver
    {
        string ResolveTemplate(string location, string templateName);
    }
}
