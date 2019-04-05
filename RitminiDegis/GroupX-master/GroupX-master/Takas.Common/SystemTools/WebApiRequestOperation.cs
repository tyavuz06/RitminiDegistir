using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;


namespace Takas.Common.SystemTools
{
	public class WebApiRequestOperation
	{
		public static HttpResponseMessage WebApiRequestOperationMethodForUser(string uriString,string requestUri, User user)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(uriString);
			HttpResponseMessage result = client.PostAsJsonAsync(requestUri, new User
			{
				Password = user.Password,
				Email = user.Email
			}).Result;

			if (result.StatusCode == HttpStatusCode.OK)
			{
			}

			return null;
		}
	}
}
