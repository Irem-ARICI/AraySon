namespace AraySon.Dtos
{
    public class CreateOrEditUrunDto
    {
        public Guid? Id { get; set; }
        public string Ad { get; set; }
        public int DersId { get; set; }
        public int KategoriId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Fiyat { get; set; }
        public string LinkUrl { get; set; }
    }
}
