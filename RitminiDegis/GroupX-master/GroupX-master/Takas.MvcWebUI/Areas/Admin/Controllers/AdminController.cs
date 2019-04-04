using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Takas.Entities.Concrete;

namespace Takas.MvcWebUI.Areas.Admin.Controllers
{
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

		[HttpPut]
		public ActionResult Update(User user)
		{
			//Todo Web Api uzerinden islem yapacagiz
			return View();
		}

		[HttpDelete]
		public ActionResult Delete(int ID)
		{
			//Todo Web Api uzerinden islem yapacagiz
			return View();
		}












	}
}