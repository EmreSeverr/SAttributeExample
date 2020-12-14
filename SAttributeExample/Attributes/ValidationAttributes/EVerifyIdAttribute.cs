using SAttributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace SAttributeExample.Attributes.ValidationAttributes
{
    public class EVerifyIdAttribute : SVerifyIdAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
