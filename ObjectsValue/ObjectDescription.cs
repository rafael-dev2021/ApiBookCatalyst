using System.ComponentModel.DataAnnotations;

namespace APIBookCatalyst.ObjectsValue
{
    public class ObjectDescription
    {
        [Required]
        public string? Description { get; }

        public ObjectDescription(string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is invalid.");
            if (description.Length < 10)
                throw new ArgumentException("Minimum 10 characters.");
            if (description.Length > 2000)
                throw new ArgumentException("Maximum 2000 characters.");

            Description = description;
        }
    }
}
