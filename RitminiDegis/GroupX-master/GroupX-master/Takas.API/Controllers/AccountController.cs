using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Takas.Business.Abstract;
using Takas.Common;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;

namespace Takas.API.Controllers
{
	[EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]

	public class AccountController : ApiController
	{
		IUserService _userService;
		ITokenService _tokenService;
		private IProductService _productService; // Bunu tamamen gereksiz olarak ekledim silicez. tekrar push etmem lazim ondan ekledim.

		public AccountController(IUserService userService, IProductService productService, ITokenService tokenService)
		{
			_userService = userService;
			_productService = productService;
			_tokenService = tokenService;
		}




		[HttpPost]
		//[WebApiAuthorize(Roles = "Admin,User")] // Biz Yazdik, Admin veya User Rollerine sahip kullanici bunu calistirabilecek
		[Route("api/Account/Login")]
		// Buradaki Donus Tipleri Object ya da User yada Baska birsey olmayacak
		// Buradaki Donus Tiplerimiz IHttpActionResult olarak donecegiz. O Yuzden ResponseType belirliyorum ki hangi turle islem yaptigimizi Gorelim.
		// Daha Eklemedik ama Calisma Prensibimiz bu olacak. Bunun nedeni ise Biz Burada Sadece veri donusu yapiyoruz eger bir hata olursa sistem kendi kafasina gore hata codu atayacak
		// Yani 200 ok demekti ya 401 bilmem ne hatasi bunlari kendisi atiyor ama bi return OK(user) diyerek okay dondugumuzu NotFound() diyerek atiyorum 500 kodunu gonderecegiz
		// buda su ise yarayacak karsi tarafta bu kodu alan yazilimci buna gore islem yapmasi gerektigini bilecek aksi durumda kullanici sistemin verecegi hatayi alacak buda kullaniciya detayli aciklama vermemis olacak.
		// Denemdim ama normalde HttpResponseMessage olarak donersek ModelState i gonderek icersiinde ayrina hangi hatanin oldugunu bildirebiliyoruz ama IHttpActionResult ta modelstate donebilir miyiz emin degilim. (MANTIKEN DONEBILIRIZ ODA BIR OBJECT SONUCTA NESYSE BAKACAGIZ BUNLARA)
		//	[WebApiAuthorize]
		//	[Authorize]
		public object Login(User user)
		{
			LoginResponse loginResponse = new LoginResponse();
			try
			{
				user = _userService.CheckUser(user);
				if (user == null)
				{
					loginResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.NOTFOUND);
					loginResponse.Token = null;
					return loginResponse;
				}
				else
				{
					Token token = new Token()
					{
						User_ID = user.ID,
						IP = "",
						OS = "",
						ExpireDate = DateTime.Now.AddDays(1),
						Browser = "",
						StartDate = DateTime.Now,
						TokenValue = RandomSfr.Generate(60),
					};

					#region Burasi Cozuldu- Sorunsuz bir sekilde WebApiConfig te yazdigimiz 3 satir json code ile cozuldu
					/*User lUser = new User()
                    {
                        ID = user.ID,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Image = user.Image,
                        AccountCreateDate = user.AccountCreateDate,
                        AccountActiveDate = user.AccountActiveDate,
                        ValidationKey = user.ValidationKey,
                        WrongCount = user.WrongCount,
                        RoleID = user.RoleID,
                        isActive = user.isActive,
                        ActiveStatus = user.ActiveStatus,
                        isBlocked = user.isBlocked,
                        Password = user.Password,
                        Tokens = null
                    };*/
					#endregion

					_tokenService.Add(token);
					loginResponse.Token = token;
					loginResponse.Token.User = user;
					loginResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SUCCESS);
					return loginResponse;
				}
			}
			catch (Exception ex)
			{
				loginResponse.setError(Common.SystemConstants.SystemConstannts.ERROR_CODES.SYSTEMERROR);
				return loginResponse;
			}
		}

		[HttpPost]
		[Route("api/Account/SignUp")]
		public async Task<bool> SignUp(User user)
		{
			try
			{
				
				var typeFullName = this.GetType().GetMethod("SignUp").Name;

				bool result = await _userService.AddUserWithDataAnnotation(user, typeFullName);
				if (result)
				{
					string link = "<a href='http://localhost:50903/Account/Activate?email=" + user.Email + "&valKey=" + Security.sha512encrypt(user.ValidationKey) + "'>";
					string subjectName = "ProjectX Aktivasyon İşlemi";
					//todo image işi ayarlanacak.
					string image = "";
					string body = "Kayıt işlemini tamamlamak için lütfen linke " + link + "tıklayınız.</a>" + image;
					result = await Takas.Common.MailOperations.SendMailForSignUp(subjectName, body, user.Email);
				}
				return result;
			}
			catch (Exception ex)
			{
				return false;
			}

		}


		[HttpGet]
		[Route("api/Account/Activate/")]
		public async Task<bool> Activate(string email, string valKey)
		{
			User user = _userService.GetUserByEmail(email);
			if (user != null)
			{
				string userKey = Security.sha512encrypt(user.ValidationKey);
				if (userKey == valKey)
				{
					user.isActive = true;
					try
					{
						return await _userService.UpdateAsync(user);
					}
					catch
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
