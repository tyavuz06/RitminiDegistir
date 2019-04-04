using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takas.Common.SystemConstants
{
    public class FacebookEntegration
    {
        const string APIID = "958753294515704";//"1156176144545912";//
        const string SECRETKEY = "a77614a903afbf8f773c0f06295f08c8"; //"cf33a7b17de11a033c3514a61ea2b233";//
        const string REDIRECTURI = "http://localhost:50903/Account/FacebookLoginResult";


        public static string getfburl()
        {
            Facebook.FacebookClient fb = new Facebook.FacebookClient();

            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = APIID,// "1156176144545912",
                client_secret = SECRETKEY,//  "cf33a7b17de11a033c3514a61ea2b233",
                redirect_uri = REDIRECTURI,//  "http://localhost:50903/Account/FacebookLoginResult",
                response_type = "code",
                scope = "user_birthday, email"
            });

            return loginUrl.AbsoluteUri;
        }
    }
}
