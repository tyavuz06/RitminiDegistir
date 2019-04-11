using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Business.Abstract
{
	public interface IWebApiTokenKeyService
	{
		void Add(WebApiTokenKey entity);
		void Update(WebApiTokenKey entity);
		void Delete(WebApiTokenKey entity);

		Task<List<WebApiTokenKey>> GetList();
		WebApiTokenKey GetKey(string apiKey);
		WebApiTokenKey GetByName(string userName);
	}
}
