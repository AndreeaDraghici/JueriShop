using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string? nume { get; set; }
        public string? prenume { get; set; }

        public string? parola { get; set; }

        public Produs? produs { get; set; }

        public Cos? cos { get; set; }

        public Review? review { get; set; }
    }
}
