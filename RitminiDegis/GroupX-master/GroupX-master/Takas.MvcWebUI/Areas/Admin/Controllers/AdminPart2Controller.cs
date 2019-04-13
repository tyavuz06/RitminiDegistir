using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Takas.Common.Entities.Concrete;


namespace Takas.MvcWebUI.Areas.Admin.Controllers
{
    public class AdminPart2Controller : Controller
    {
        #region
        // GET: Admin/AdminPart2
        public ActionResult CategoryList()
        {
            return View("_PartialPageAdminPanelCategoryList");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            //Todo Burada Kullanici ekleme islemi yapilacak WebApi uzerinden.	
            //ToDo viewbag ile deger gonderelim bu sayfamiza kullanici kayit olduktan sonra ekrana popup acip kullanci basarili bir sekilde kaydoldu diyebiliriz.
            return View();
        }

        public ActionResult Update(int id)
        {
            //Todo Web Api uzerinden islem yapacagiz
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                //Todo WebApi ye gonder Kayit Islemini Yapsin
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Delete(int id)
        {
            // Todo Web Api uzerinden islem yapacagiz
            //todo Gelen id ye gore 
            return RedirectToAction("CategoryList");
        }
        #endregion

        public ActionResult MessageList()
        {
            return View("_PartialPageAdminPanelMessageList");
        }

    }
}