using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.DataAccess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		Task<bool> AddUserWithDataAnnotationAsyn(User entity,string methodName);

		int UserAddReturnUserId(User entity);
	}
}
