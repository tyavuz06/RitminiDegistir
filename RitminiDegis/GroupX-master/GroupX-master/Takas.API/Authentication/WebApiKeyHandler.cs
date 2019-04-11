using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Takas.Business.Abstract;
using Takas.Common;
using Takas.Common.SystemConstants;

namespace Takas.API.Authentication
{
	// Bu Classimizi Herkes WebApi ye istedigi zaman erisemesin arada bir guvenlik olsun diye ekliyoruz.
	// WebApiConfig dosyasinda buradaki gerekli configuration islemini yapmamiz lazim.
	public class WebApiKeyHandler : DelegatingHandler
	{
		private IWebApiTokenKeyService _webApiTokenKeyService;

		public WebApiKeyHandler(IWebApiTokenKeyService apiTokenKeyService)
		{
			_webApiTokenKeyService = apiTokenKeyService;
		}

		// Burada Request geliyor bunun icerisinde webapi key i ariyacagiz. Eger bu var ise tamam bu adam guvebli diyip gecmesine izin verecegiz ama yok ise daha action a gitmeden istek iptal edecegiz.
		// Bu islemin gerceklesebilmesi icin [Authorize] attribute lerini eklememiz lazzim ya class seviyesinde ya da action seviyesinde eklemelisin. // KendiAuthorize attribute umuzu yazdik role islemleri icin
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var queryString = request.RequestUri.ParseQueryString(); // Burasi Bana bir Collection donduruyor name value seklinde
																	 //var apiKey = queryString["apiKey"];
			string apiKey;
			string bizdekiApiKey;
			if (String.IsNullOrEmpty(queryString["apiKey"]))
			{
				 apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
			}
			else
			{
				apiKey = queryString["apiKey"].ToString();
				bizdekiApiKey = SystemConstannts.apiValue;

				if (Security.sha512encrypt(bizdekiApiKey) != apiKey) // Mail adresinden gelen apikey ile Bizim kendi sistemimizdeki apiKey birbirlerinie esit ise
				{
					return base.SendAsync(request, cancellationToken);
				}
			}

			
			
			
			// Header dan almak icin ustteki code blogunu kapatip alttaki code blogunu acacagiz

			// heasder a apiKey :"Kullanicinin Verecegi Key" seklinde gonderilir.
			//	var key = request.Headers.GetValues("apiKey");
			// Bu gelen apiKey e ait bir kullanici var mi buna bakmamiz lazim.

			// Burayi soyle dusunelim arkadaslar. Veritabaninda Tamamen bir ayri tablo olusturacagiz ayni facebook authentication islemindeki gibi bize bir key veriyor biz o key ile cekiyoruz ya ayni mantik burada bir tablo olusturacagiz hepsinden bagimsiz orada key value seklinde apikey tutacagiz. (Biz WebApi kullanicisi Ekleme islemini yapmayacagiz yani facebook taki gibi bir sisteme kayit olma islemi yapmayip burayi elle yazma taraftariyim yani hem mobil hemde mvc tarafi icin elle key ekleyecegiz ve sistem her istek geldigi zaman bu key var mi yok mu diye kontrol edecek yani dirasidan biri bu web api ye istek attigi zaman puufff you have been banned  MadaLavir :D) 

			// Alt satirdaki kod veritabanina tablo eklenince yapilacaktir.
			var kullaniciVarMi = _webApiTokenKeyService.GetKey(apiKey); // Kullanici Var ise bu sekilde bize kullanici donecektir

			// BUradaki Tablomuzda UserId UserKey Username ve UserRole tutabiliriz.
			// UserRole leri soyle dusunelim belki sadece get yapmak icin userRole A deriz hem veri ceksin hem eklesin userRola A,B olabilir ondan dolayi.

			// Bu islemlerimiz sayesinde WebApi miz daha guvenli hale geliyor.

			// If blogu veritabani islemi  yapildiginda aciklacaktir tekrardan

			if (kullaniciVarMi != null)
			{
				var principal = new ClaimsPrincipal(new GenericIdentity(kullaniciVarMi.UserName, "APIKey")); // Bir Principal Olusturkduk ezberlemeye gerek yok burayi
				HttpContext.Current.User = principal; // Sonra bunu current user a atiyoruz boylece actionlarimizin uzerindeki [Authorize] attribute unu bu ust taraftaki code blogu asip action icine girecektir.
													  //	// Kullanici var ise current.user icerisinde otomatikman action islemine girip oradaki code bloglari calisacaktir
													  //	// eger kullaniciVarMi null gelirse sistem bu request islemini UnAuthorize olarak isleme alip kullaniciya izin vermiyecektir.
													  // KendiAuthorize attribute umuzu yazdik role islemleri icin
													  //return base.SendAsync(request, cancellationToken);
			}




			return base.SendAsync(request, cancellationToken);
		}
	}
}