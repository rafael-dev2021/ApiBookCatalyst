using System.ComponentModel.DataAnnotations;

namespace APIBookCatalyst.ObjectsValue
{
    public class ObjectStock
    {
        [Required]
        [Range(1, 999999)]
        public int Stock { get; }

        public ObjectStock(int stock)
        {
            if (stock < 1)
                throw new ArgumentException("Invalid stock value, minimum 1.");
            Stock = stock;
        }
    }
}
