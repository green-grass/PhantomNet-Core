using PhantomNet.ComponentModel.DataAnnotations.SharedResources;

namespace System.ComponentModel.DataAnnotations
{
    public class LocalizedMaxLengthAttribute : MaxLengthAttribute
    {
        public LocalizedMaxLengthAttribute() : base()
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(CommonValidationMessages);
        }

        public LocalizedMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(CommonValidationMessages);
        }
    }
}
