using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Abstractions;

namespace CrudTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        public string Name { get; set; }

        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10000.")]
        public decimal Price { get; set; }
    }
}
