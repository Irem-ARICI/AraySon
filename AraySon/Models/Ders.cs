using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraySon.Models
{
    [Table("Ders")]
    public class Ders
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ders adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ders adı en az 3, en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }
    }
}
