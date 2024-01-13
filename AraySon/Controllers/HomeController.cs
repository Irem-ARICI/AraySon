using AraySon.Data;
using AraySon.Models;
using AraySon.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AraySon.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IKategoriService _kategoriService;
        private readonly IDersService _dersService;
        private readonly ILogger<HomeController> _logger;



        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ILogger<HomeController> logger, IUrunService urunService, IKategoriService kategoriService, IDersService dersService)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
            _dersService = dersService;
            _logger = logger;
        }

        public IActionResult Index(int dersId = -1, int kategoriId = -1)
        {
            var dersler = _dersService.DersGet();
            dersler.Insert(0, new Ders { Id = -1, Ad = "Tümü" });

            var kategoriler = _kategoriService.KategoriGet();
            kategoriler.Insert(0, new Kategori { Id = -1, Ad = "Tümü" });



            var model = new HomeIndexViewModel()
            {
                DersId=dersId,
                KategoriId = kategoriId,
                Dersler = dersler,
                Kategoriler = kategoriler,
                Urunler = _urunService.UrunlerGet(new Dtos.GetUrunlerInput
                {
                    KategoriId = kategoriId,
                    DersId = dersId
                })
            };

            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
