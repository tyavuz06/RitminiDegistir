using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Takas.API.Authentication
{
	public class WebApiAuthorizeAttribute :AuthorizeAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			// Buradaki Roles Actionlarin uzerinde yazdigimiz Role lerden gelmektedir. String olarak Admin yazdiysak Admin gelir. Oyle dusun bunu
			var actionRoles = Roles; // Hani BU Attribute umuzu bir action ustunde yazdik ya. Burada o attribute lere verdigimiz roles leri yakalayabiliyoruz.
			var userName = HttpContext.Current.User.Identity.Name; // Burasi Bizim WebApiKeyHandler da yazdigimiz Name i cekiyor ve userName e atiyor. ApiKeyHandler daki Name i yakaladik.
			// Bu name e gore veritabanindan bu userName e sahip olanlari cekecegiz.

			//var user = _webApiAuthentication.Get(userName); // Gidip Bu userName a ait kullaniciyi getiriyoruz. / Yeni olusturacagim tablodaki veri

			//if (user == null && actionRoles.Contains(user.Role) == false)
			//{
			//	actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

			//} BURASI ISLEMLER TAMAMLANINCA ACILACAK
			
			// Eger Istedigimiz degerlerle uyusmuyorsa if bloguna duser ve bize statuscode unauthorized doner

			//base.OnAuthorization(actionContext); Burasina gerek yok
		}
	}
}