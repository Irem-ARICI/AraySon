using AraySon.Dtos;
using AraySon.Models;
using AraySon.Services;
using Microsoft.AspNetCore.Mvc;

namespace AraySon.Controllers
{

    public class UrunController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IKategoriService _kategoriService;
        private readonly IDersService _dersService;

        public UrunController(IUrunService urunService, IKategoriService kategoriService, IDersService dersService)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
            _dersService = dersService;
        }

        public IActionResult Index()
        {
            var urunler = _urunService.UrunlerGet(new Dtos.GetUrunlerInput { DersId = -1, KategoriId = -1 });

            return View(urunler);
        }

        public IActionResult Ekle()
        {
            var model = new UrunEkleGuncelleViewModel()
            {
                Kategoriler = _kategoriService.KategoriGet(),
                Dersler = _dersService.DersGet(),
                Urun = new CreateOrEditUrunDto()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Ekle(UrunEkleGuncelleViewModel input)
        {
            _urunService.UrunEkleGuncelle(input.Urun);

            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(Guid id)
        {
            var urun = _urunService.UrunIdGet(id);

            var urunDto = new CreateOrEditUrunDto
            {
                Id = urun.Id,
                Ad = urun.Ad,
                Fiyat = urun.Fiyat,
                ImageUrl = urun.ImageUrl,
                KategoriId = urun.KategoriId,
                DersId = urun.DersId,
                LinkUrl = urun.LinkUrl,
            };

            var model = new UrunEkleGuncelleViewModel()
            {
                Kategoriler = _kategoriService.KategoriGet(),
                Dersler = _dersService.DersGet(),
                Urun = urunDto
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(UrunEkleGuncelleViewModel input)
        {
            _urunService.UrunEkleGuncelle(input.Urun);

            return RedirectToAction("Index");
        }
    }
}
