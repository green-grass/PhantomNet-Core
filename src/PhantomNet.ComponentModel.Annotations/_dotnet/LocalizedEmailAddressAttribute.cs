﻿namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class LocalizedEmailAddressAttribute : DataTypeAttribute
    {
        public LocalizedEmailAddressAttribute()
            : base(DataType.EmailAddress)
        {
            ErrorMessageResourceName = nameof(EmailAddressAttribute).Replace("Attribute", string.Empty);
            ErrorMessageResourceType = typeof(ValidationMessages);
        }

        public override bool IsValid(object value)
        {
            return new EmailAddressAttribute().IsValid(value);
        }
    }
}
