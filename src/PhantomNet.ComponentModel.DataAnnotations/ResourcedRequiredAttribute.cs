namespace System.ComponentModel.DataAnnotations
{
    public class ResourcedRequiredAttribute : RequiredAttribute
    {
        public ResourcedRequiredAttribute()
        {
            ErrorMessageResourceName = nameof(RequiredAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(Resources);
        }
    }
}
