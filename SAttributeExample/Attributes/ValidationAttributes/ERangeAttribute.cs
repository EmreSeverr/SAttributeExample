using SAttributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace SAttributeExample.Attributes.ValidationAttributes
{
    public class ERangeAttribute : SRangeAttribute
    {
        public ERangeAttribute(int minValue, int maxValue) : base(minValue, maxValue)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
