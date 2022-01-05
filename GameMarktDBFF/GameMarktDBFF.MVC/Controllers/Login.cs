using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMarktDBFF.MVC.Controllers

{
    public class Login : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alogin(SistemAdmini adminFormu)
        {   using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var kullanicikontrol = db.SistemAdmini.FirstOrDefault(
                    s => s.kullanici_adi == adminFormu.kullanici_adi && s.sifre == adminFormu.sifre );

                if( kullanicikontrol != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanicikontrol.kullanici_adi, false);
                    return RedirectToAction("/index", "admin");
                }
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
                return View("index");
            }
               
        }
    }
}