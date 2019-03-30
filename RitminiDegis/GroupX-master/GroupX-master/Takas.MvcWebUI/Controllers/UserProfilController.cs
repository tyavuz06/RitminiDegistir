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
            return RedirectToAction("ListOfUserProduct");
        }

        public ActionResult ListOfUserProduct()
        {
            ViewBag.PageInfo = "ÜRÜNLERİM";
	        return View("Index");
        }

        public ActionResult Profil()
        {
            ViewBag.PageInfo = "PROFİLİM";
            return View("Index");
        }

        public ActionResult Exchanges()
        {
            ViewBag.PageInfo = "TAKASLARIM";
            return View("Index");
        }
        public ActionResult Messages()
        {
            ViewBag.PageInfo = "MESAJLARIM";
            return View("Index");
        }
    }
}