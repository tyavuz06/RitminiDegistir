using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.MvcWebUI.Areas.Admin.Authentication;


namespace Takas.MvcWebUI.Areas.Admin.Controllers
{

	//TODO Web Api lere gitmeden once ModelState lerimizi kontrol edelim hata varsa webapi ye gitmeyecegiz bunlari unutma.
	[MyAuthentication]
	public class AdminController : Controller
	{
		#region Ctor

		private IUserService _userservice;
		private IBrandService _brandService;

		public AdminController(IUserService userservice, IBrandService brandService)
		{
			_userservice = userservice;
			_brandService = brandService;
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
			TempData.Keep();
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
			user.RoleID = 1;
			if (ModelState.IsValid)
			{
				_userservice.Update(user);
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




		#region Brand List

		public ActionResult BrandList()
		{
			List<Brand> brands;
			try
			{
				brands = _brandService.GetList();
				return View(brands);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new ContentResult();
			}

		}

		#endregion


		#region Brand Add

		public ActionResult AddBrand()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddBrand(Brand brand)
		{
			if (!ModelState.IsValid)
			{
				return View(brand);
			}

			try
			{
				_brandService.AddBrand(brand);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return View();
		}
		#endregion



		#region Brand Update




		public ActionResult BrandUpdate(int id)
		{
			try
			{
				Brand brand = _brandService.Get(id);
				return View(brand);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpNotFound();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult BrandUpdate(Brand brand)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_brandService.Update(brand);
					return RedirectToAction("Index");
				}
				else
				{
					return View(brand);
				}


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return HttpNotFound();
			}
		}
		#endregion


		#region Brand Delete




		public ActionResult BrandDelete(int id)
		{
			try
			{
				var brand = _brandService.Get(id);
				_brandService.Detele(brand);
				return RedirectToAction("BrandList");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpNotFound();
			}
		}
		#endregion
	}
}