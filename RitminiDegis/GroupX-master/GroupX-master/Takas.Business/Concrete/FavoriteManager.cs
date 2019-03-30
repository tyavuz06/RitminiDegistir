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
	public class FavoriteManager : IFavoriteService
	{
		private IFavoriteDal _favoriteDal;

		public FavoriteManager(IFavoriteDal favoriteDal)
		{
			_favoriteDal = favoriteDal;
		}

		public Task<List<Favorite>> GetList()
		{
			return _favoriteDal.GetList();
		}

		public Favorite Get(int id)
		{
			return _favoriteDal.Get(x => x.ID == id);
		}

		public void Add(Favorite entity)
		{
			_favoriteDal.Add(entity);
		}

		public void Update(Favorite entity)
		{
			_favoriteDal.Update(entity);
		}

		public void Delete(Favorite entity)
		{
			_favoriteDal.Delete(entity);
		}
	}
}
