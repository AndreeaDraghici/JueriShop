using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Categorie
    {
        [Key]
        public int idCategorie { get; set; }
        public string? denumire { get; set; }

        public Produs? produs { get; set; }

    }
}
