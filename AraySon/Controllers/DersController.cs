using AraySon.Dtos;
using AraySon.Services;
using Microsoft.AspNetCore.Mvc;

namespace AraySon.Controllers
{
    public class DersController : Controller
    {
        private readonly IDersService _dersService;

        public DersController(IDersService dersService)
        {
            _dersService = dersService;
        }

        public IActionResult Index()
        {
            var dersler = _dersService.DersGet();

            return View(dersler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(CreateOrEditDersDto input)
        {
            _dersService.DersEkleGuncelle(input);

            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int id)
        {
            var ders = _dersService.DersIdGet(id);

            var model = new CreateOrEditDersDto
            {
                Id = ders.Id,
                Ad = ders.Ad
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(CreateOrEditDersDto input)
        {
            _dersService.DersEkleGuncelle(input);

            return RedirectToAction("Index");
        }
    }
}
