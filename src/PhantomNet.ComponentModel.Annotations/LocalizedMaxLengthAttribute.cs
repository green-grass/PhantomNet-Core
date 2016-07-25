namespace System.ComponentModel.DataAnnotations
{
    public class LocalizedMaxLengthAttribute : MaxLengthAttribute
    {
        public LocalizedMaxLengthAttribute() : base()
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(ValidationMessages);
        }

        public LocalizedMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(ValidationMessages);
        }
    }
}
