using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Business.Abstract;
using Takas.DataAccess.Abstract;
using Takas.Entities.Concrete;

namespace Takas.Business.Concrete
{
	public class ExchangeManager :IExchangeService
	{
		private IExchangeDal _exchangeDal;

		public ExchangeManager(IExchangeDal exchangeDal)
		{
			_exchangeDal = exchangeDal;
		}

		public Task<List<Exchange>> GetList()
		{
			return _exchangeDal.GetList();
		}

		public Exchange Get(int id)
		{
			return _exchangeDal.Get(x => x.ID == id);
		}

		public void Add(Exchange entity)
		{
			_exchangeDal.Add(entity);
		}

		public void Update(Exchange entity)
		{
			_exchangeDal.Update(entity);
		}

		public void Delete(Exchange entity)
		{
			_exchangeDal.Delete(entity);
		}
	}
}
