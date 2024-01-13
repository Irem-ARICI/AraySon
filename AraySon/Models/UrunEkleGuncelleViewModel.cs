using AraySon.Dtos;

namespace AraySon.Models
{
    public class UrunEkleGuncelleViewModel
    {
        public CreateOrEditUrunDto Urun { get; set; }
        public List<Kategori> Kategoriler { get; set; }
        public List<Ders> Dersler { get; set; }
    }
}
