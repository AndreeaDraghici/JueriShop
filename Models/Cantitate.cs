using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Cantitate
    {
        [Key]
        public int idCantitate { get; set; }

        public int cantitatateTotala { get;set; }

        public ICollection<Cos>? cosuri { get; set; }

    }
}
