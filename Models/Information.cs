using System.ComponentModel.DataAnnotations;

namespace CrudTest.Models
{
    public class Information
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public List<string> KnownLanguage { get; set; }
        [Required]
        public string MotherTongue { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

    }
}
