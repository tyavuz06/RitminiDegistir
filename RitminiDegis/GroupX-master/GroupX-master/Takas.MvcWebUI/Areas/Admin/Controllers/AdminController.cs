using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;


namespace Takas.MvcWebUI.Areas.Admin.Controllers
{

	//TODO Web Api lere gitmeden once ModelState lerimizi kontrol edelim hata varsa webapi ye gitmeyecegiz bunlari unutma.
	public class AdminController : Controller
	{
		#region Ctor
		IUserService _userservice;
		public AdminController(IUserService userservice)
		{
			_userservice = userservice;
		}
		#endregion




		#region Index Sayfasi - UserList Cekiliyoruz ayrica
		// GET: Admin/Admin
		public async Task<ActionResult> Index()
		{
			Models.UserShowViewModel model = new Models.UserShowViewModel();

			model.Users = await _userservice.GetList();
			TempData["UserShowViewModel"] = model;
			return View(model);

		}

		public ActionResult UserList()
		{
			var model = TempData["UserShowViewModel"];
			return View("_PartialPageAdminPanelUserList", model);
		}
		#endregion



		#region User Ekleme Islemleri

		[HttpGet]
		public ActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddUser(User user)
		{
			// Eger Gelen Kullanici Validation lari gecememis ise geriye gonderiyoruz.
			if (!ModelState.IsValid)
			{
				return View(user);
			}

			try
			{
				await _userservice.AddUser(user);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

			}

			//ToDo viewbag ile deger gonderelim bu sayfamiza kullanici kayit olduktan sonra ekrana popup acip kullanci basarili bir sekilde kaydoldu diyebiliriz.
			return View();
		}

		#endregion




		#region User Update Islemleri

		public ActionResult Update(int id)
		{
			if (id == 0)
			{
				return HttpNotFound();
			}

			User updateUser = null;
			try
			{
				updateUser = _userservice.Get(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

			}

			return View(updateUser);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Update(User user)
		{
			if (ModelState.IsValid)
			{
				await _userservice.UpdateAsync(user);
				return RedirectToAction("Index");
			}
			else
			{
				return View(user);
			}
		}

		#endregion




		#region User Delete Islemleri
		public ActionResult Delete(int id)
		{
			if (id == 0)
			{
				return HttpNotFound();
			}

			try
			{
				var user = _userservice.Get(id);
				_userservice.Delete(user);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return RedirectToAction("Index");
		}
		#endregion
	}
}