using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Takas.Common.Entities.Concrete;


namespace Takas.MvcWebUI.Areas.Admin.Controllers
{

	//TODO Web Api lere gitmeden once ModelState lerimizi kontrol edelim hata varsa webapi ye gitmeyecegiz bunlari unutma.
	public class AdminController : Controller
	{
		// GET: Admin/Admin
		public ActionResult Index()
		{
			//todo Bu sayfada bir model gidcek bu model de User Class imizi gonderecek. Veritabanindaki tum kullanicilari buraya gonderecegiz. WebApi den gelecek buraya degerler. Admin Panel aslinda Web Api ile calismasa da olur mu acaba bunu bir dusunelim.

			
			
			


			return View();
		}

		public ActionResult UserList()
		{
			//todo Bu sayfada bir model gidcek bu model de User Class imizi gonderecek. Veritabanindaki tum kullanicilari buraya gonderecegiz. WebApi den gelecek buraya degerler.

			return View("_PartialPageAdminPanelUserList");
		}

		[HttpGet]
		public ActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddUser(User user)
		{
			//Todo Burada Kullanici ekleme islemi yapilacak WebApi uzerinden.	
			//ToDo viewbag ile deger gonderelim bu sayfamiza kullanici kayit olduktan sonra ekrana popup acip kullanci basarili bir sekilde kaydoldu diyebiliriz.
			return View();
		}

		public ActionResult Update(int id)
		{
			//Todo Web Api uzerinden islem yapacagiz
			//Todo gidip Id ye gore Bu degerleri cekecegiz sonra bunu view a bascacagiz.
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(User user)
		{
			if (ModelState.IsValid)
			{
				//Todo WebApi ye gonder Kayit Islemini Yapsin
				return RedirectToAction("Index");
			}
			else
			{
				return View(user);
			}
		}

		public ActionResult Delete(int id)
		{
			//Todo Web Api uzerinden islem yapacagiz
			//todo Gelen id ye gore 
			return RedirectToAction("Index");
		}

	}
}