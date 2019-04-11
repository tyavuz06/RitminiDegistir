using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentValidation.Results;
using Takas.Business.Abstract;
using Takas.Business.ValidationRules.FluentValidation.FluentValidationRules;
using Takas.Business.ValidationRules.FluentValidation.ValidationTool;
using Takas.Common;
using Takas.Common.Entities.Concrete;
using Takas.Common.SystemConstants;
using Takas.DataAccess.Abstract;


namespace Takas.Business.Concrete
{
    
    public class SocialUserManager : ISocialUserService
    {
        ISocialUserDal _socialUserDal;
        IUserDal _userDal;
        ITokenDal _tokenDal;
        public SocialUserManager(ISocialUserDal socialUserDal, IUserDal userDal, ITokenDal tokenDal)
        {
            _socialUserDal = socialUserDal;
            _userDal = userDal;
            _tokenDal = tokenDal;
        }

        public bool SocialUserOperation(int socialType, string socialID, string email, string username, string firstname, string lastname,string methodName)
        {

            //bu kullanıcı daha once kayıt olmuşmu
            SocialUser socialUser = _socialUserDal.Get(t => t.SOCIALID == socialID && t.SocialType == socialType);
            //daha önce kayıt olmamış ise
            if (socialUser == null)
            {
                //bir kullanıcı tanımlama
                User user = new User
                {

                    ActiveStatus = (int)SystemConstannts.Situation.SOCİALUSER,
                    Email = "a@a.com",
                    Name = firstname,
                    Surname = lastname,
                    isActive = true,
                    Password = Common.RandomSfr.Generate(8),
                    AccountCreateDate = DateTime.Now,
                    AccountActiveDate = DateTime.Now,
                    Address = "hdfdjfdk jdhdfjd",
                    PhoneNumber = "12344555"

                };
                //user.Tokens = new List<Token>();

                //o kullanıcıyı socialUser olarak atama
                socialUser = new SocialUser
                {
                    CreateDate = DateTime.Now,
                    SocialType = socialType,
                    SOCIALID = socialID,
                    UserID = user.ID
                };

                //o kullanıcıya token oluşturma
                Token token = new Token
                {
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddHours(6),
                    TokenValue = Security.sha512encrypt(RandomSfr.Generate(20)),
                };
                //user.Tokens.Add(token);
                HttpCookie cok = new HttpCookie("userauth", token.TokenValue);
                cok.Expires = DateTime.Now.AddHours(6);
                HttpContext.Current.Response.Cookies.Add(cok);
                HttpContext.Current.Session["User"] = user;

                //oluşturulan user ve socialuser ı database e kayıt etme
                _userDal.Add(user);
                var userr = _userDal.Get(t => t.Name == user.Name && t.Surname == user.Surname && t.Password == user.Password);
                socialUser.UserID = userr.ID;

                if (String.IsNullOrEmpty(methodName))
                {
	                ValidationTool.Validate(new UserValidator(), user);
	                UserValidator validator = new UserValidator();
	                ValidationResult result = validator.Validate(user);

					// TANSU BURAYA DUSMESI LAZIM CODUN
					// Kullaniciyi eklemeden buraya breakpoint koyar misin bakalim buraya dusucek mi
					// Tam _socialUserDal.Add(socialUser); un oraya koy ekleme yapmasin ama oraya dustugunu gorelim
					_socialUserDal.Add(socialUser);
				}
                else
                {
	                ValidationTool.Validate(new UserValidatorNotNull(), user);
	                UserValidatorNotNull validator = new UserValidatorNotNull();
	                ValidationResult result = validator.Validate(user);

                }
				// _socialUserDal.Add(socialUser); buradaydi If icerisine aldim


				try
				{

                    return true;

                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            else
            {
                int id = socialUser.UserID;
                Token tkn = _tokenDal.Get(t => t.User_ID == id);
                List<SocialUser> socialUserEager;
                if (tkn.ExpireDate < DateTime.Now)
                {
                    //bu kullanıcı daha once kayıt olmuş ise ve token expiredate zamanı geçmiş ise Token ekle
                    Token token = new Token
                    {
                        StartDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddHours(6),
                        TokenValue = Security.sha512encrypt(RandomSfr.Generate(20)),
                    };
                    //socialUser.User.Tokens.Add(token); işlemi için oluşturulan EagerLoadingUser() mettodundan socialuser alma
                    socialUserEager = EagerLoadingUser();
                    foreach (var item in socialUserEager)
                    {
                        item.User.Tokens.Add(token);
                    }

                    HttpCookie cok = new HttpCookie("userauth", token.TokenValue);
                    cok.Expires = DateTime.Now.AddHours(6);
                    HttpContext.Current.Response.Cookies.Add(cok);
                }
                socialUserEager = EagerLoadingUser();
                foreach (var item in socialUserEager)
                {

                    HttpContext.Current.Session["User"] = item.User;
                }

                try
                {

                    return true;

                }
                catch (Exception ex)
                {

                    return false;
                }
            }

            return false;
        }
        // BURASI EAGERLOADING i çekiyor
        public List<SocialUser> EagerLoadingUser()
        {
	        return _socialUserDal.EagerLoadingWithParams(null,x=>x.User.Tokens);
        }
	}
}
