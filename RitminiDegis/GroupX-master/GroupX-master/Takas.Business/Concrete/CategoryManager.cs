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
	public class CategoryManager :ICategoryService
	{
		private ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public Task<List<Category>> GetList()
		{
			return _categoryDal.GetList();
		}

		public Category Get(int id)
		{
			return _categoryDal.Get(x => x.ID == id);
		}

		public void Add(Category entity)
		{
			_categoryDal.Add(entity);
		}

		public void Update(Category entity)
		{
			_categoryDal.Update(entity);
		}

		public void Delete(Category entity)
		{
			_categoryDal.Delete(entity);
		}
	}
}
