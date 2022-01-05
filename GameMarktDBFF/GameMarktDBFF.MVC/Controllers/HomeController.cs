using GameMarktDBF2.DAL.Models;
using GameMarktDBFF.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameMarktDBFF.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly GameMarktContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GameMarktContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VpSatinAl()
        {
            return View();
        }

        public IActionResult UcSatinAl()
        {
            return View();
        }

        public IActionResult RpSatinAl()
        {
            return View();
        }

        public IActionResult SteamSatinAl()
        {
            return View();
        }
        public IActionResult Destek()
        {
            return View();
        }
        public IActionResult Oyunlar()
        {
            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }
        public IActionResult KayıtOl()
        {
            return View();
        }
        public IActionResult GirisAnasayfa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KayitOl([Bind("MusteriId,Adi,Soyadi,EmailId,RolId,Password")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.RolId = 1;
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GirisOyunlar));
            }
            return View();
        }


        public IActionResult GirisVp()
        {
            return View(_context.Urun.ToList());
        }
        public IActionResult GirisPubg()
        {
            return View();
        }
        public IActionResult GirisSteam()
        {
            return View();
        }
        public IActionResult GirisRp()
        {
            return View(_context.Urun.ToList());
        }
        public IActionResult SatinAlma()
        {
            return View();
        }
        public IActionResult GirisOyunlar()
        {
            
            return View(_context.Urun.ToList());
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
