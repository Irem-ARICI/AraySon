namespace AraySon.Dtos
{
    public class UrunDto
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string KategoriAdi { get; set; }
        public string DersAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string ImageUrl { get; set; }

        public string LinkUrl { get; set; }
    }
}
