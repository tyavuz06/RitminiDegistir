using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Takas.Common.Entities.Concrete;
using Takas.Common.Response;
using Takas.Common.SystemConstants;

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
                client.DefaultRequestHeaders.Add(SystemConstannts.apiKey, SystemConstannts.apiValue);
                client.BaseAddress = new Uri("http://localhost:2765/");


                HttpResponseMessage result = client.PostAsJsonAsync("api/Token/GetUserFromTokenValue/", new Token
                {
                    TokenValue = tokenFromCookie
                }).Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Token\":null}")
                    {
                        TokenResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(resultString);
                        if (tokenResponse.Code == 1)
                        {
                            if (tokenResponse.Token.User != null)
                            {
                                HttpContext.Current.Session["User"] = tokenResponse.Token.User;
                                return tokenResponse.Token.User;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}