using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class TakasContextInitializer : DropCreateDatabaseIfModelChanges<TakasContext>
	{
		protected override void Seed(TakasContext context)
		{
			context.WebApiTokenKeys.Add(new WebApiTokenKey
			{ UserName = "AdminKullanici", UserKey = "de3ae6a3-47ae-4145-95ab-0af13a3cb80e", UserRole = "Admin" });
			base.Seed(context);
		}
	}
}
