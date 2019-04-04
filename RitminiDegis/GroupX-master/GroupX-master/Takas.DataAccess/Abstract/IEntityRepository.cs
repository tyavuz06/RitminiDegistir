using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Takas.Entities.Abstract;

namespace Takas.DataAccess.Abstract
{
	public interface IEntityRepository<T> where T : class, IEntity, new()
	{

		Task<List<T>> GetList(Expression<Func<T, bool>> Filter = null);


		List<T> GetListWihEagerLoading(string eagerLoading, Expression<Func<T, bool>> Filter = null);

		List<T> EagerLoadingWithParams(Expression<Func<T, bool>> Filter = null,
			params Expression<Func<T, object>>[] paths);

		T Get(Expression<Func<T, bool>> Filter);

		void Add(T entity);
		Task<bool> AddAsync(T entity);

		void Update(T entity);

		void Delete(T entity);

	}
}
