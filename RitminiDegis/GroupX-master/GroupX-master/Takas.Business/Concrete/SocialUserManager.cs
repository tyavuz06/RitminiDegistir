﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Takas.Business.Abstract;
using Takas.Common;
using Takas.Common.SystemConstants;
using Takas.DataAccess.Abstract;
using Takas.Entities.Concrete;

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

        public bool SocialUserOperation(int socialType, string socialID, string email, string username, string firstname, string lastname)
        {
            //todo:burdan devam edilecektir
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
                    Surname=lastname,
                    Password = Common.RandomSfr.Generate(8),
                    AccountCreateDate = DateTime.Now,
                    AccountActiveDate=DateTime.Now,
                    Address="hdfdjfdk jdhdfjd",
                    PhoneNumber="12344555"

                };
                user.Tokens = new List<Token>();

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
                user.Tokens.Add(token);
                HttpCookie cok = new HttpCookie("userauth", token.TokenValue);
                cok.Expires = DateTime.Now.AddHours(6);
                HttpContext.Current.Response.Cookies.Add(cok);
                HttpContext.Current.Session["User"] = user;


                _userDal.Add(user);
                _socialUserDal.Add(socialUser);


                try
                {
                    //db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            else
            {
                //bu kullanıcı daha once kayıt olmuş ise Token ekle
                Token token = new Token
                {
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddHours(6),
                    TokenValue = Security.sha512encrypt(RandomSfr.Generate(20)),
                };
                //socialUser.User.Tokens.Add(token);
                HttpCookie cok = new HttpCookie("userauth", token.TokenValue);
                cok.Expires = DateTime.Now.AddHours(6);
                HttpContext.Current.Response.Cookies.Add(cok);
                HttpContext.Current.Session["User"] = socialUser.User;

                try
                {
                    //db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {

                    return false;
                }
            }

            return false;
        }
    }
}
