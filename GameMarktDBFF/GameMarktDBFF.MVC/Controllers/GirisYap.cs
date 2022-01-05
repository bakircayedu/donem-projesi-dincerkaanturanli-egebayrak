using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameMarktDBF2.DAL.Models;
using Microsoft.Extensions.Logging;
using System.Web;

namespace GameMarktDBFF.MVC.Controllers
{
    public class GirisYap : Controller
    {
       public GameMarktContext _context;

        public GirisYap(ILogger<GirisYap> logger, GameMarktContext context)
        {
            
            _context = context;
        }

    

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Musteri musteri)
        {
            var bilgiler = _context.Musteri.FirstOrDefault(x => x.EmailId == musteri.EmailId && x.Password == musteri.Password);
            if(bilgiler != null)
            {
                FormsAut
            }
        }
    }
}
