using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;
using Takas.DataAccess.Abstract;


namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, TakasContext>, IUserDal
	{
		public async Task<bool> AddUserWithDataAnnotationAsyn(User entity, string methodName)
		{
			using (TakasContext context = new TakasContext())
			{
				try
				{
					context.Entry(entity).State = EntityState.Added;
					await context.SaveChangesAsync();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public int UserAddReturnUserId(User entity)
		{
			using (TakasContext context = new TakasContext())
			{
				try
				{
					context.Entry(entity).State = EntityState.Added;
					context.SaveChanges();
					return entity.ID;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}
		}
	}
}
