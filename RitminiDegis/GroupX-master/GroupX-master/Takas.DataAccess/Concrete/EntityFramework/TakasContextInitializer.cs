using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common;
using Takas.Common.Entities.Concrete;
using Takas.Common.SystemConstants;

namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class TakasContextInitializer : DropCreateDatabaseIfModelChanges<TakasContext>
	{
		protected override void Seed(TakasContext context)
		{
			context.WebApiTokenKeys.Add(new WebApiTokenKey
			{ UserName = "AdminKullanici", UserKey = "de3ae6a3-47ae-4145-95ab-0af13a3cb80e", UserRole = "Admin" });
			base.Seed(context);

			for (int i = 0; i < 10; i++)
			{
				var user = context.Users.Add(new User
				{
					Name = "Recep Mert" + i,
					AccountActiveDate = DateTime.Now,
					AccountCreateDate = DateTime.Now,
					ActiveStatus = 1,
					Address = "Egitim" + i,
					Email = "merlin19951996@homtail.com",
					Password = Security.sha512encrypt("rece"+i),
					PhoneNumber = "535 453 16 01",
					Surname = "ASLAN",
					RoleID = 1,
					ValidationKey = RandomSfr.Generate(10),
					WrongCount = 0,
					isActive = false,
					isBlocked = false,
				});
				context.Tokens.Add(new Token()
				{
					User_ID = user.ID,
					IP = "",
					OS = "",
					ExpireDate = DateTime.Now.AddDays(1),
					Browser = "",
					StartDate = DateTime.Now,
					TokenValue = RandomSfr.Generate(60),
				});
			}
		}
	}
}
