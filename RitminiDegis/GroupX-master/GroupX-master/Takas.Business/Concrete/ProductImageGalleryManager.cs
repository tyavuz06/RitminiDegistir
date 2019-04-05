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
	public class ProductImageGalleryManager :IProductImageGalleryService
	{
		private IProductImageGalleryDal _productImageGalleryDal;

		public ProductImageGalleryManager(IProductImageGalleryDal productImageGalleryDal)
		{
			_productImageGalleryDal = productImageGalleryDal;
		}

		public Task<List<ProductImageGallery>> GetList()
		{
			return _productImageGalleryDal.GetList();
		}

		public ProductImageGallery Get(int id)
		{
			return _productImageGalleryDal.Get(x => x.ID == id);
		}

		public void Add(ProductImageGallery entity)
		{
			_productImageGalleryDal.Add(entity);
		}

		public void Update(ProductImageGallery entity)
		{
			_productImageGalleryDal.Update(entity);
		}

		public void Delete(ProductImageGallery entity)
		{
			_productImageGalleryDal.Delete(entity);
		}
		
		public async Task<List<ProductImageGallery>> GetImageGallery(int ID)
        {
            List<ProductImageGallery>  imageGallery= await _productImageGalleryDal.GetList(t => t.Product_ID == ID);
            return imageGallery;
        }
	}
}
