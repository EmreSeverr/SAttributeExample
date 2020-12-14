using SAttributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace SAttributeExample.Attributes.ValidationAttributes
{
    public class EStringLengthAttribute : SStringLengthAttribute
    {
        public EStringLengthAttribute(int maxValue) : base(maxValue)
        {

        }

        public EStringLengthAttribute(int minValue, int maxValue) : base(minValue, maxValue)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
