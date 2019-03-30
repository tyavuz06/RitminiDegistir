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
        // GET: UserProfil
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOfUserProduct()
        {
			

	        return View();
        }
    }
}