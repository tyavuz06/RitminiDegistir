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
	public class RoleManager :IRoleService
	{
		private IRoleDal _roleDal;

		public RoleManager(IRoleDal roleDal)
		{
			_roleDal = roleDal;
		}

		public Task<List<Role>> GetList()
		{
			return _roleDal.GetList();
		}

		public Role Get(int id)
		{
			return _roleDal.Get(x => x.ID == id);
		}

		public void Add(Role entity)
		{
			_roleDal.Add(entity);
		}

		public void Update(Role entity)
		{
			_roleDal.Update(entity);
		}

		public void Delete(Role entity)
		{
			_roleDal.Delete(entity);
		}
	}
}
