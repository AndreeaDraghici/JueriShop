using System.ComponentModel.DataAnnotations;

namespace JueriOnlineShop.Models
{
    public class Produs
    {
        [Key]
        public int idProdus { get; set; }

        [Display(Name = "Nume")]
        public string? numeProdus { get; set; }

        [Display(Name = "Descriere")]
        public string? descriereProdus { get; set; }

        [Display(Name = "Pret")]
        public int pretProdus { get; set; }

        [Display(Name = "Imagine")]
        public string? photoURL { get; set; }

        public ICollection<Categorie>? categorii { get; set; }

        public ICollection<User>? utilizatori { get; set; }  

        public Review? review { get; set; }

        public Comanda? commanda { get; set; }
        


    }
}
