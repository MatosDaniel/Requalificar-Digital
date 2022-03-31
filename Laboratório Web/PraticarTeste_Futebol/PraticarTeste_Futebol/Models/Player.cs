using System.ComponentModel.DataAnnotations;

namespace PraticarTeste_Futebol.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }
        public Team team { get; set; }
    }
}
