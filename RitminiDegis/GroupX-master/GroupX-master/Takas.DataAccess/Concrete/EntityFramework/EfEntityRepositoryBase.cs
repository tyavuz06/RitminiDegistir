using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Abstract;
using Takas.DataAccess.Abstract;


namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
	{

		public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> Filter = null)
		{
			using (TContext context = new TContext())
			{
				return await (Filter == null ? context.Set<TEntity>().ToListAsync() : context.Set<TEntity>().Where(Filter).ToListAsync());
			}
		}

		public List<TEntity> GetListWithoutTask(Expression<Func<TEntity, bool>> Filter = null)
		{
			using (TContext context = new TContext())
			{
				return Filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(Filter).ToList();
			}
		}

		public List<TEntity> GetListWihEagerLoading(string eagerLoading, Expression<Func<TEntity, bool>> Filter = null)
		{
			using (TContext context = new TContext())
			{
				return Filter == null
					? context.Set<TEntity>().Include(eagerLoading).ToList()
					: context.Set<TEntity>().Include(eagerLoading).Where(Filter).ToList();
			}
		}

		public List<TEntity> EagerLoadingWithParams(Expression<Func<TEntity, bool>> Filter = null, params Expression<Func<TEntity, object>>[] paths)
		{
			using (TContext context = new TContext())
			{
				var sonuc = context.Set<TEntity>().Include(paths.First());
				foreach (var eager in paths.Skip(1))
				{
					sonuc = sonuc.Include(eager);
				}

				return Filter == null ? sonuc.ToList() : sonuc.Where(Filter).ToList();
			}
		}



		public List<TEntity> EagerLoadingParamsAndSelect(Expression<Func<TEntity, bool>> Filter = null, Expression<Func<TEntity, TEntity>> FilterSelect = null, params Expression<Func<TEntity, object>>[] paths)
		{
			using (TContext context = new TContext())
			{
				var sonuc = context.Set<TEntity>().Include(paths.First());
				foreach (var eager in paths.Skip(1))
				{
					sonuc = sonuc.Include(eager);
				}

				if (Filter == null && FilterSelect == null)
				{
					return sonuc.ToList();
				}
				if (Filter != null && FilterSelect == null)
				{
					return sonuc.Where(Filter).ToList();
				}
				if (Filter != null && FilterSelect != null)
				{

					return context.Set<TEntity>().Include(paths.First()).Where(Filter).Select(FilterSelect).ToList();
				}
				return null;
			}
		}


		public TEntity Get(Expression<Func<TEntity, bool>> Filter)
		{
			using (TContext context = new TContext())
			{
				return context.Set<TEntity>().Where(Filter).FirstOrDefault();
			}
		}
		public void Add(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				try
				{
					context.Entry(entity).State = EntityState.Added;
					context.SaveChanges();
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
				
			}
		}

		public async Task<bool> AddAsync(TEntity entity)
		{
			using (TContext context = new TContext())
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

		public async Task<bool> UpdateAsync(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				try
				{
					context.Entry(entity).State = EntityState.Modified;
					await context.SaveChangesAsync();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}
		public void Update(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				context.Entry(entity).State = EntityState.Modified;
				context.SaveChanges();
			}
		}

		public void Delete(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				context.Entry(entity).State = EntityState.Deleted;
				context.SaveChanges();
			}
		}


	}
}
