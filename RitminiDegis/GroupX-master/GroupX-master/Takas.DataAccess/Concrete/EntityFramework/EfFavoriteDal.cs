using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.DataAccess.Abstract;
using Takas.Entities.Concrete;

namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class EfFavoriteDal : EfEntityRepositoryBase<Favorite, TakasContext>, IFavoriteDal
	{
	}
}
