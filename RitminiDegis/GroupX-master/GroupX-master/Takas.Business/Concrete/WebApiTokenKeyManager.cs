using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;
using Takas.DataAccess.Abstract;

namespace Takas.Business.Concrete
{
	public class WebApiTokenKeyManager : IWebApiTokenKeyService
	{
		private IWebApiTokenKeyDal _webApiTokenKeyDal;

		public WebApiTokenKeyManager(IWebApiTokenKeyDal webApiTokenKeyDal)
		{
			_webApiTokenKeyDal = webApiTokenKeyDal;
		}

		public void Add(WebApiTokenKey entity)
		{
			_webApiTokenKeyDal.Add(entity);
		}

		public void Update(WebApiTokenKey entity)
		{
			_webApiTokenKeyDal.Update(entity);
		}

		public void Delete(WebApiTokenKey entity)
		{
			_webApiTokenKeyDal.Delete(entity);
		}

		public async Task<List<WebApiTokenKey>> GetList()
		{
			return await _webApiTokenKeyDal.GetList();
		}

		public WebApiTokenKey GetKey(string apiKey)
		{
			return _webApiTokenKeyDal.Get(x => x.UserKey == apiKey);
		}

		public WebApiTokenKey GetByName(string userName)
		{
			return _webApiTokenKeyDal.Get(x => x.UserName == userName);
		}
	}
}
