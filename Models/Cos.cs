using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Cos
    {
        [Key]
        public int idCos { get; set; }

        public int idProdus { get; set; }

        public int cantitate_ { get; set; }

        public int idCantitate { get; set; }
        public Cantitate? cantitate { get; set; }
    }
}
