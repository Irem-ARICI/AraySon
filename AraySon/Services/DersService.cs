using AraySon.Data;
using AraySon.Dtos;
using AraySon.Models;

namespace AraySon.Services
{
    public class DersService : IDersService
    {
        private readonly ApplicationDbContext _context;

        public DersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ders DersIdGet(int id)
        {
            return _context.Dersler
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
        }


        public List<Ders> DersGet()
        {
            var dersler = _context.Dersler
                .OrderBy(x => x.Ad)
                .ToList();

            return dersler;
        }

        public void DersEkleGuncelle(CreateOrEditDersDto input)
        {
            if (!input.Id.HasValue)
            {
                DersEkle(input);
            }
            else
            {
                DersGuncelle(input);
            }
        }

        public void DersSil(int id)
        {
            var gelenDers = _context.Dersler
                .Where(x => x.Id == id)
                .FirstOrDefault();
            _context.Dersler.Remove(gelenDers);
            _context.SaveChanges();
        }


        public void DersEkle(CreateOrEditDersDto input)
        {
            _context.Dersler.Add(new Ders
            {
                Ad = input.Ad,
            });

            _context.SaveChanges();
        }

        public void DersGuncelle(CreateOrEditDersDto input)
        {
            var gelenDers = _context.Dersler
                .Where(x => x.Id == input.Id.Value)
                .FirstOrDefault();

            if (gelenDers != null)
            {
                gelenDers.Ad = input.Ad;

                _context.Dersler.Update(gelenDers);

                _context.SaveChanges();
            }

        }
    }
}
