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
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Task<List<Brand>> GetList()
        {
            return _brandDal.GetList();
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(x => x.ID == id);
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }
    }
}
