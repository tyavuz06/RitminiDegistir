using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Business.Abstract
{
	public interface IBrandService
	{
		List<Brand> GetList();
		void AddBrand(Brand brand);
		Brand Get(int id);
		void Update(Brand brand);
		void Detele(Brand brand);
	}
}
