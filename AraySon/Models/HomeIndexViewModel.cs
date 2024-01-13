using AraySon.Dtos;

namespace AraySon.Models
{
    public class HomeIndexViewModel
    {
        public int DersId { get; set; }
        public int KategoriId { get; set; }
        public List<Ders> Dersler { get; set; }
        public List<Kategori> Kategoriler { get; set; }

        public List<UrunDto> Urunler { get; set; }
    }
}
