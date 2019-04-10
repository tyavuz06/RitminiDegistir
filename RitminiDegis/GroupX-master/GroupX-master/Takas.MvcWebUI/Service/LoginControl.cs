using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;

namespace Takas.MvcWebUI.Service
{
    public class LoginControl
    {
        public static User ControlLogin()
        {

            if (HttpContext.Current.Session["User"] != null)
            {
                return (User)HttpContext.Current.Session["User"];
            }

            if (HttpContext.Current.Request.Cookies["userAuth"] != null)
            {
                string tokenFromCookie = HttpContext.Current.Request.Cookies["userAuth"].Value;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:2765/");
				

                HttpResponseMessage result = client.PostAsJsonAsync("api/Token/GetUserFromTokenValue/", new Token {
                    TokenValue = tokenFromCookie
                }).Result;
                string resultString = result.Content.ReadAsStringAsync().Result;
				if (result.StatusCode == HttpStatusCode.OK)
                {
                    //string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Token\":null}")
                    {
                        TokenResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(resultString);
                        if (tokenResponse.Code == 1)
                        {
                            if (tokenResponse.User != null)
                            {
                                //HttpResponseMessage result2 = client.PostAsJsonAsync("api/User/GetUserFromID", tokenResponse.Token.User_ID).Result;
                                //if (result.StatusCode == HttpStatusCode.OK)
                                //{
                                //    string resultString2 = result.Content.ReadAsStringAsync().Result;
                                //    if (resultString != "{\"User\":null}")
                                //    {
                                //        UserResponse userResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResponse>(resultString2);
                                //        if (userResponse.Code == 1)
                                //        {
                                //            if (userResponse.User != null)
                                //            {
                                //                HttpContext.Current.Session["User"] = userResponse.User;
                                //                return userResponse.User;
                                //            }
                                //        }
                                //    }
                                //}
                                return null;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}