using SAttributes.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAttributeExample.DTOs
{
    public class ProductDTO
    {
        [SVerifyId]
        public int Id { get; set; }

        [SStringLength(2, 10, ErrorMessage = "Barcode number must be max length is 10 and min lenght 2.")]
        public String Barcode { get; set; }

        [SStringLength(2, 100, ErrorMessage = "Name must be max length is 10 and min lenght 2.")]
        public String Name { get; set; }

        [SRange(0, int.MaxValue, ErrorMessage = "Product price can not be less than 0.")]
        public decimal UnitPrice { get; set; }
    }
}
