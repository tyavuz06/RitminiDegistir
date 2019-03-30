using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Takas.MvcWebUI.Controllers
{
	/// <summary>
	/// Kullanici Kendi takas listelerini goruntuleyip bilgielrini guncelleyebilecek
	/// </summary>
    public class UserProfilController : Controller
    {
        public UserProfilController()
        {
        }

        // GET: UserProfil

        public ActionResult Index()
        {
            ViewBag.PageInfo = "BENİM SAYFAM";
            return View();
        }
        public ActionResult MyProducts()
        {
            ViewBag.PageInfo = "ÜRÜNLERİM";
            return View();
        }
        public ActionResult Profil()
        {
            ViewBag.PageInfo = "PROFİLİM";
            return View();
        }

        public ActionResult Exchanges()
        {
            ViewBag.PageInfo = "TAKASLARIM";
            return View();
        }
        public ActionResult Messages()
        {
            ViewBag.PageInfo = "MESAJLARIM";
            return View();
        }
    }
}