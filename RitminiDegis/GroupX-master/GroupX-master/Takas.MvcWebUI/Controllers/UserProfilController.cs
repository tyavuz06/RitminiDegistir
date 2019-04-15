using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;
using Takas.Common.SystemConstants;
using Takas.Common.SystemTools;
using Takas.MvcWebUI.Service;

namespace Takas.MvcWebUI.Controllers
{
    /// <summary>
    /// Kullanici Kendi takas listelerini goruntuleyip bilgielrini guncelleyebilecek
    /// </summary>
    public class UserProfilController : Controller
    {
        public UserProfilController()
        {
        }
        // GET: UserProfil
        public ActionResult Index()
        {
            return RedirectToAction("MyProducts");
        }
        public ActionResult MyProducts()
        {
            if (LoginControl.ControlLogin() != null)
            {
                ViewBag.PageInfo = "ÜRÜNLERİM";
                HttpResponseMessage result = WebApiRequestOperation.WebApiRequestOperationMethodForUser(SystemConstannts.WebApiDomainAddress, "api/UserProfile/GetMyProducts", (HttpContext.Session["User"] as Takas.Common.Entities.Concrete.User));
                GetUserProductResponse response = null;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (!resultString.Contains("{\"Products\":null"))
                    {
                        response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetUserProductResponse>(resultString);
                    }
                }
                return View(response);
            }
            return View("NotFound");

        }
        public ActionResult Profil()
        {
            if (LoginControl.ControlLogin() != null)
            {
                ViewBag.PageInfo = "PROFİLİM";
                return View((HttpContext.Session["User"] as User));
            }
            else
                return View("NotFound");
        }

        public ActionResult Exchanges()
        {
            if (LoginControl.ControlLogin() != null)
            {
                ViewBag.PageInfo = "TAKASLARIM";
                return View();
            }
            else
                return View("NotFound");
        }
        public ActionResult Messages()
        {
            if (LoginControl.ControlLogin() != null)
            {
                ViewBag.PageInfo = "MESAJLARIM";
                return View();
            }
            else
                return View("NotFound");
        }
    }
}