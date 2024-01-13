using AraySon.Data;
using AraySon.Dtos;
using AraySon.Models;

namespace AraySon.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly ApplicationDbContext _context;

        public KategoriService(ApplicationDbContext context)
        {

            _context = context;
        }


        

        private void KategoriEkle(CreateOrEditKategoriDto? input)
        {
           _context.Kategoriler.Add(new Kategori
            {
                Ad = input.Ad,
            });

            _context.SaveChanges();
           
        }
        private void KategoriGuncelle(CreateOrEditKategoriDto input)
        {
            var gelenKategori = _context.Kategoriler
                .Where(x => x.Id == input.Id.Value)
                .FirstOrDefault();
            if (gelenKategori == null)
            {
                gelenKategori.Ad = input.Ad;
                _context.Kategoriler.Update(gelenKategori);
                _context.SaveChanges();
            }
        }

        public void KategoriEkleGuncelle(CreateOrEditKategoriDto input)
        {
            if (!input.Id.HasValue)
            {
                KategoriEkle(input);
            }
            else
            {
                KategoriGuncelle(input);
            }
        }

       

        public void KategoriSil(int id)
        {
            var gelenKategori = _context.Kategoriler
                .Where(x => x.Id == id)
                .FirstOrDefault();
            _context.Kategoriler.Remove(gelenKategori);
            _context.SaveChanges(); 
        }

        public Kategori KategoriIdGet(int id)
        {
            return _context.Kategoriler
                .Where(x=>x.Id==id)
                .FirstOrDefault();
        }

        public List<Kategori> KategoriGet()
        {
            var kategoriler = _context.Kategoriler
                .OrderBy(x => x.Ad)
                .ToList();

            return kategoriler;
        }
    }
}
