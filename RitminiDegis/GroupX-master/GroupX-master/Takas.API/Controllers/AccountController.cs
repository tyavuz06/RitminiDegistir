using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
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
        [Route("api/Account/Login")]
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
