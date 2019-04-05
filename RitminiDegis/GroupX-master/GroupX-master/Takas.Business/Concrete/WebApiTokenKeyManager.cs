using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.DataAccess.Abstract;

namespace Takas.Business.Concrete
{
	public class WebApiTokenKeyManager :IWebApiTokenKeyService
	{
		private IWebApiTokenKeyDal _webApiTokenKeyDal;

		public WebApiTokenKeyManager(IWebApiTokenKeyDal webApiTokenKeyDal)
		{
			_webApiTokenKeyDal = webApiTokenKeyDal;
		}
	}
}
