using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Comanda
    {
        [Key]
        public int idComanda { get; set; }

        public string? statusComanda { get; set; }

        public ICollection<Cantitate>? cantitate { get; set; }

        public ICollection<Produs>? produs { get; set; }
    }
}
