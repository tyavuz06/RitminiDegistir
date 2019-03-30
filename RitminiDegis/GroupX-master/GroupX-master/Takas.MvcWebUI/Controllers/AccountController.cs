using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Takas.Entities.Concrete;
using System.Net;
using System.Net.Http;
using Takas.Business.Concrete;
using Takas.Business.Abstract;
using Takas.Common;

namespace Takas.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Loginn
        User user = new User();
        public ActionResult Login()
        {
            ViewBag.Title = "ProjectX | Giriş";
            return View(user);
        }
        public ActionResult SignUp()
        {
            ViewBag.Title = "ProjectX | Kayıt";
            return View(user);
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2765/");
                //client.BaseAddress = new Uri("http://localhost:54640/");
                HttpResponseMessage result = client.PostAsJsonAsync("api/Account/Login", new User
                {
                    Password = user.Password,
                    Email = user.Email
                }).Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != null)
                    {
                        user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(resultString);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return View("Login", user);
                }
                else
                    return RedirectToAction("Login", "Login", user);
            }
            else
                return RedirectToAction("Login", "Login", user);

        }

        public ActionResult SignUpUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.AccountActiveDate = DateTime.Now;
                user.AccountCreateDate = DateTime.Now;
                user.Password = Security.sha512encrypt(user.Password).Substring(0, 70);
                user.Image = "";
                user.isActive = false;
                user.isBlocked = false;
                user.ValidationKey = RandomSfr.Generate(10);
                user.WrongCount = 0;
                user.RoleID = 1;


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2765/");
                HttpResponseMessage result = client.PostAsJsonAsync("api/Account/SignUp", user).Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString.Contains("true"))
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                        return RedirectToAction("SignUp", "Account", user);
                }
            }
            return RedirectToAction("SignUp", "Account", user);
        }
    }
}