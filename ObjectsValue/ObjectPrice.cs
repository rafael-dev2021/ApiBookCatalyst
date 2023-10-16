using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBookCatalyst.ObjectsValue
{
    public class ObjectPrice
    {
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; }

        public ObjectPrice(decimal price)
        {
            if (price <= 0.99m)
                throw new ArgumentException("Price is invalid, minimum value is $ 1.00");
            Price = price;
        }
    }
}
