﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Business.Concrete;
using Takas.DataAccess.Concrete.EntityFramework;
using Takas.Entities.Concrete;

namespace Takas.MvcWebUI.Controllers
{
	public class HomeController : Controller
	{
		#region Yavuz
		//GET: Home
		//IUserService _userService = new UserManager();
		//public async Task<ActionResult> Index()
		//{
		//    User user = new User()
		//    {
		//        Address = "Pendik",
		//        Name = "yavuz",
		//        Surname = "ünlü",
		//        Email = "yavuz_unlu_@hotmail.com",
		//        Password = "kasap3406",
		//        isActive = true,
		//        isBlocked = false,
		//        PhoneNumber = "05538056875",
		//        AccountActiveDate = DateTime.Now,
		//        AccountCreateDate=DateTime.Now,
		//        Image="",
		//        ValidationKey="",
		//        WrongCount=0,
		//        RoleID=1
		//    };
		//    _userService.AddUser(user);
		//    ViewBag.title = "Anasayfa";
		//    return View();
		//}

		#endregion

		
		
		public ActionResult Index()
		{ 		
			ViewBag.title = "Anasayfa";
			return View();
		}
	}
}