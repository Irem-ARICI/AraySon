using AraySon.Dtos;
using AraySon.Services;
using Microsoft.AspNetCore.Mvc;

namespace AraySon.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        public IActionResult Index()
        {
            var kategoriler = _kategoriService.KategoriGet();

            return View(kategoriler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(CreateOrEditKategoriDto input)
        {
            _kategoriService.KategoriEkleGuncelle(input);

            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int id)
        {
            var kategori = _kategoriService.KategoriIdGet(id);

            var model = new CreateOrEditKategoriDto
            {
                Id = kategori.Id,
                Ad = kategori.Ad
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(CreateOrEditKategoriDto input)
        {
            _kategoriService.KategoriEkleGuncelle(input);

            return RedirectToAction("Index");
        }
    }
}
