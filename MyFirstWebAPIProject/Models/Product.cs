using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPIProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
