namespace System.ComponentModel.DataAnnotations
{
    public class ResourcedRequiredAttribute : RequiredAttribute
    {
        public ResourcedRequiredAttribute()
        {
            ErrorMessageResourceName = "Required";
            ErrorMessageResourceType = typeof(Resources);
        }
    }
}
