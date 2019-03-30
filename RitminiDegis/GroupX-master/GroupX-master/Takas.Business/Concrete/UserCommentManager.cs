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
	public class UserCommentManager :IUserCommentService
	{
		private IUserCommentDal _UserCommentDal;

		public UserCommentManager(IUserCommentDal userCommentDal)
		{
			_UserCommentDal = userCommentDal;
		}
		

		public Task<List<UserComment>> GetList()
		{
			return _UserCommentDal.GetList();
		}

		public UserComment Get(int id)
		{
			return _UserCommentDal.Get(x => x.ID == id);
		}

		public void Add(UserComment entity)
		{
			_UserCommentDal.Add(entity);
		}

		public void Update(UserComment entity)
		{
			_UserCommentDal.Update(entity);
		}

		public void Delete(UserComment entity)
		{
			_UserCommentDal.Delete(entity);
		}
	}
}
