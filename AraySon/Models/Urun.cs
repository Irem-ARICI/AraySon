using AraySon.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraySon.Models
{
    [Table("Urun")]
    public class Urun
    {
        public Guid Id { get; set; }
        public List<Urun> Urunler { get; set; }
        
        [Required(ErrorMessage = "Ürün adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ürün adı en az 3, en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        public decimal Fiyat { get; set; }
        public int DersId { get; set; }

        public string ImageUrl { get; set; }
        public string LinkUrl {  get; set; }

        //public bool Like {  get; set; }

        [ForeignKey("DersId")]
        public Ders DersFk { get; set; }

        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public Kategori KategoriFk { get; set; }

    }
}
