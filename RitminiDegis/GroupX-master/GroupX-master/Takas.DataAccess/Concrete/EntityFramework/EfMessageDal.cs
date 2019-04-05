using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;
using Takas.DataAccess.Abstract;


namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class EfMessageDal : EfEntityRepositoryBase<Message, TakasContext>, IMessageDal
	{
	}
}
