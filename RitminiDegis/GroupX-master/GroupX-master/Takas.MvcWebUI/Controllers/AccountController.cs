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
    //burada değişiklik var
    public class AccountController : Controller
    {
        ITokenService _tokenService;
        ISocialUserService _socialUserService;
        public AccountController(ISocialUserService socialUserService, ITokenService tokenService)
        {
            _socialUserService = socialUserService;
            _tokenService = tokenService;
        }

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
                        Token token = new Token()
                        {
                            User_ID = user.ID,
                            IP = "",
                            OS = "",
                            ExpireDate = DateTime.Now.AddDays(1),
                            Browser = "",
                            StartDate = DateTime.Now,
                            TokenValue = RandomSfr.Generate(60),
                            User = user
                        };
                        HttpCookie httpCookie = new HttpCookie("userAuth",token.TokenValue);
                        HttpContext.Response.Cookies.Add(httpCookie);
                        HttpContext.Session["User"] = user;
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


        public ActionResult FacebookLoginResult()
        {
            string code = Request["code"];
            Facebook.FacebookClient fb = new Facebook.FacebookClient();
            fb.AppId = "958753294515704";
            fb.AppSecret = "a77614a903afbf8f773c0f06295f08c8";

            fb.AccessToken = code;

            dynamic result = fb.Post("/oauth/access_token", new
            {
                client_id = "958753294515704",
                client_secret = "a77614a903afbf8f773c0f06295f08c8",
                code = code,
                redirect_uri = "http://localhost:50903/Account/FacebookLoginResult"
            });

            fb.AccessToken = result.access_token;
            dynamic userdata = fb.Get("me");

            string name = userdata.name;
            string[] fullname=name.Split(' ');
            userdata.firstname = fullname[0];
            userdata.lastname = fullname[1];
            bool serviceresult = _socialUserService.SocialUserOperation((int)Common.SystemConstants.SystemConstannts.SOCIAL_TYPE.FACEBOOK, userdata.id, userdata.email, userdata.name, userdata.firstname, userdata.lastname);

            if (serviceresult)
            {
                return RedirectToAction("Index", "Home", new { });
            }

            return null;
        }
        public String GetAccessToken(string code)
        {
            WebClient client = new WebClient();

            string url = "https://graph.facebook.com/oauth/access_token?" + "client_id=" + "1156176144545912" + "&client_secret=" + "cf33a7b17de11a033c3514a61ea2b233" + "&code=" + code + "&redirect_uri=http:%2F%2Flocalhost:5176%2F";

            string result = client.DownloadString(url);



            string accessToken = result.Split('&')[0];
            accessToken = accessToken.Split('=')[1];

            return accessToken;
        }
    }
}