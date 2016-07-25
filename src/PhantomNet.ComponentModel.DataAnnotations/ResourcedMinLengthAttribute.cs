namespace System.ComponentModel.DataAnnotations
{
    public class ResourcedMinLengthAttribute : MinLengthAttribute
    {
        public ResourcedMinLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceName = nameof(MinLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(ValidationMessages);
        }
    }
}
