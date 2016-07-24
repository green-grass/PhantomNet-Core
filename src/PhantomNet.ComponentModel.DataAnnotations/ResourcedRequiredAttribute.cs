using System.ComponentModel.DataAnnotations;

namespace PhantomNet.ComponentModel.DataAnnotations
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
