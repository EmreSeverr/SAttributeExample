using SAttributeExample.Attributes.ValidationAttributes;
using System;

namespace SAttributeExample.DTOs
{
    public class ProductDTO
    {
        [EVerifyId]
        public int Id { get; set; }

        [EStringLength(2, 10, ErrorMessage = "Barcode number must be max length is 10 and min lenght 2.")]
        public String Barcode { get; set; }

        [EStringLength(2, 100, ErrorMessage = "Name must be max length is 10 and min lenght 2.")]
        public String Name { get; set; }

        [ERange(0, int.MaxValue, ErrorMessage = "Product price can not be less than 0.")]
        public decimal UnitPrice { get; set; }
    }
}
