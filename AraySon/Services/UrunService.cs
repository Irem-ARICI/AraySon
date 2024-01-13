using AraySon.Data;
using AraySon.Dtos;
using AraySon.Models;
using Microsoft.EntityFrameworkCore;

namespace AraySon.Services
{
    public class UrunService : IUrunService
    {
        private readonly ApplicationDbContext _context;
        public UrunService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UrunEkleGuncelle(CreateOrEditUrunDto input)
        {
            if (!input.Id.HasValue)
            {
                UrunEkle(input);
            }
            else
            {
                UrunGuncelle(input);
            }

        }

        private void UrunGuncelle(CreateOrEditUrunDto input)
        {
            var mevcutUrun = _context.Urunler
                .Where(x => x.Id == input.Id.Value)
                .FirstOrDefault();

            if (mevcutUrun != null)
            {
                mevcutUrun.Ad = input.Ad;
                mevcutUrun.Fiyat = input.Fiyat;
                mevcutUrun.KategoriId = input.KategoriId;
                mevcutUrun.DersId = input.DersId;


                _context.Urunler.Update(mevcutUrun);
                _context.SaveChanges();
            }
        }

        private void UrunEkle(CreateOrEditUrunDto input)
        {
            _context.Urunler.Add(new Urun
            {
                Ad = input.Ad,
                Fiyat = input.Fiyat,
                ImageUrl = input.ImageUrl,
                KategoriId = input.KategoriId,
                DersId = input.DersId,
                LinkUrl= input.LinkUrl,
            });

            _context.SaveChanges();
        }
        public void UrunSil(Guid id)
        {
            var urun = _context.Urunler.FirstOrDefault(u => u.Id == id);

            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                _context.SaveChanges();
            }
        }

        public List<UrunDto> UrunlerGet(GetUrunlerInput input)
        {
            var urunler = _context.Urunler
               .Include(x => x.DersFk)
               .Include(x => x.KategoriFk)
               .Where(x => (input.KategoriId <= 0 || input.KategoriId == x.KategoriId)
               && (input.DersId <= 0 || input.DersId == x.DersId)
               )
               .OrderBy(x => x.Ad)
               .Select(x => new UrunDto
               {
                   Id = x.Id,
                   Ad = x.Ad,
                   Fiyat = x.Fiyat,
                   KategoriAdi = x.KategoriFk.Ad,
                   DersAdi = x.DersFk.Ad,
                   ImageUrl = x.ImageUrl,
                    LinkUrl = x.LinkUrl,
               })
               .ToList();

            return urunler;
        }

        public Urun UrunIdGet(Guid id)
        {
            return _context.Urunler
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }



    }
}
