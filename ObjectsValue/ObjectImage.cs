using System.ComponentModel.DataAnnotations;

namespace APIBookCatalyst.ObjectsValue
{
    public class ObjectImage
    {
        [Required]
        public string? Image { get; set; }

        public ObjectImage()
        {
        }

        public ObjectImage(string? image)
        {
            if (string.IsNullOrWhiteSpace(image))
                throw new ArgumentException("Image is invalid.");
            if (image?.Length > 250)
                throw new ArgumentException("Maximum 250 characters.");
            Image = image;
        }

    }
}
