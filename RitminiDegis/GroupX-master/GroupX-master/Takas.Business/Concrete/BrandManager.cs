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
	public class BrandManager :IBrandService
	{
		private IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public List<Brand> GetList()
		{
			return _brandDal.GetListWithoutTask();
		}

		public void AddBrand(Brand brand)
		{
			_brandDal.Add(brand);
		}

		public Brand Get(int id)
		{
			return _brandDal.Get(x => x.ID == id);
		}

		public void Update(Brand brand)
		{
			_brandDal.Update(brand);
		}

		public void Detele(Brand brand)
		{
			_brandDal.Delete(brand);
		}
	}
}
