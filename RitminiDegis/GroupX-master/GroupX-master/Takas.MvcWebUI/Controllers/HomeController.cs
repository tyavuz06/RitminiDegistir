using System.Web.Mvc;
using Takas.MvcWebUI.Service;

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
            LoginControl.ControlLogin();
            ViewBag.title = "Anasayfa";
			return View();
		}
	}
}