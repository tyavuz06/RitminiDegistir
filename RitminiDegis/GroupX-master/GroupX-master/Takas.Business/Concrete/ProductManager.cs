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
   public class ProductManager : IProductService
   {
	   private IProductDal _productDal;
	    public ProductManager(IProductDal productDal) // Burada da productDal Ninject ile eklenecektir. Biz _productDal i kullaniyoruz.
	    {
		    _productDal = productDal;
	    }

		
		public async Task<List<Product>> GetList()
	    {

		  return  await _productDal.GetList();

	    }

		public Product Get(int id)
		{
			return _productDal.Get(x => x.ID == id);
		}

		public void Add(Product yeniProduct)
		{
			_productDal.Add(yeniProduct);
		}

		public void Update(Product yeniProduct)
		{
			_productDal.Update(yeniProduct);
		}

		public void Delete(Product yeniProduct)
		{
			_productDal.Delete(yeniProduct);
		}

		public List<Product> GetListByUserId(int userId)
		{
			return _productDal.GetListWihEagerLoading("ProductImageGalleries", x => x.User_ID == userId);
		}
   }
}
