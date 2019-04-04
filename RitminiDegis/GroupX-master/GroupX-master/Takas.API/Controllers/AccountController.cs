using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Takas.API.Authentication;
using Takas.Business.Abstract;
using Takas.Common;
using Takas.Entities.Concrete;

namespace Takas.API.Controllers
{
    [EnableCors(origins: "http://localhost:50903/", headers: "*", methods: "*")]
	
    public class AccountController : ApiController
    {
        IUserService _userService;
        private IProductService _productService; // Bunu tamamen gereksiz olarak ekledim silicez. tekrar push etmem lazim ondan ekledim.

        public AccountController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
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
        public object Login(User user)
        {
            try
            {
                User realUser = _userService.CheckUser(user);
                if (realUser == null)
                {
                    return user;
                }
                else
                    return realUser;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/Account/SignUp")]
        public async Task<bool> SignUp(User user)
        {
            try
            {
                bool result = await _userService.AddUser(user);
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
                        _userService.Update(user);
                    }
                    catch
                    {
                    }

                }
            }
            return true;
        }
    }
}
