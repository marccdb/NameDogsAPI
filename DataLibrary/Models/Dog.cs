using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class Dog
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string? OwnerName { get; set; }

        [Required]
        public string? Breed { get; set; }
    }
}
