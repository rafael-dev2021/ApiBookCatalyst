using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIBookCatalyst.ObjectsValue
{
    public partial class ObjectName
    {
        [Required]
        public string? Name { get; }

        public ObjectName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is invalid.");
            if (name.Length < 3)
                throw new ArgumentException("Minimum 3 characters.");
            if (name.Length > 40)
                throw new ArgumentException("Maximum 40 characters.");
            if (!MyRegex().IsMatch(name))
                throw new ArgumentException("Name contains invalid characters.");

            Name = name;
        }

        [GeneratedRegex("^[A-Za-zÀ-ÖØ-öø-ÿ\\s'-.]+$")]
        private static partial Regex MyRegex();
    }
}
