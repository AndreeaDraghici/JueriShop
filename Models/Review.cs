using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JueriOnlineShop.Models
{
    public class Review

    {
        [Key]
        public int idReview { get; set; }

        [Display(Name = "Descriere")]
        public string? detalii { get; set; }

        [Display(Name = "Data"), DataType(DataType.Date)]
        public DateTime? date { get; set; }

        public ICollection<Produs>? produse { get; set; }

        public ICollection<User>? users { get; set; }

    }
}
