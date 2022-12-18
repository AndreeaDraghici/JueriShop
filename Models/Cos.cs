using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Cos
    {
        [Key]
        public int idCos { get; set; }

        public ICollection<User>? utilizatori { get; set; }

        public Cantitate? cantitate { get; set; }
    }
}
