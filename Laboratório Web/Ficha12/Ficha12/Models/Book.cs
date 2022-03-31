using System.ComponentModel.DataAnnotations;

namespace Ficha12.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public Publisher Publisher { get; set; }
    }
}
