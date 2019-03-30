using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Concrete;

namespace Takas.DataAccess.Abstract
{
	public interface IProductDal :IEntityRepository<Product>
	{
	}
}
