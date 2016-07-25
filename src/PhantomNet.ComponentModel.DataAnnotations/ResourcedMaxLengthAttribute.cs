﻿namespace System.ComponentModel.DataAnnotations
{
    public class ResourcedMaxLengthAttribute : MaxLengthAttribute
    {
        public ResourcedMaxLengthAttribute() : base()
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(Resources);
        }

        public ResourcedMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceName = nameof(MaxLengthAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(Resources);
        }
    }
}