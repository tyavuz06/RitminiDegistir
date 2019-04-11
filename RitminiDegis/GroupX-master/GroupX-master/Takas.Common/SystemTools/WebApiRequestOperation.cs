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
		public static HttpResponseMessage WebApiRequestOperationMethodForUser(string webApiDomainAddress, string apiRequestAddress, object entity)
		{
		
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(webApiDomainAddress);
			client.DefaultRequestHeaders.Add(SystemConstants.SystemConstannts.apiKey, SystemConstants.SystemConstannts.apiValue);
			HttpResponseMessage result = client.PostAsJsonAsync(apiRequestAddress, entity).Result;
			return result;
		}
	}
}
