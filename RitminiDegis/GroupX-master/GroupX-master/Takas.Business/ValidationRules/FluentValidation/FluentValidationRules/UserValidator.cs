using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentValidation;
using Takas.Common.Entities.Concrete;

namespace Takas.Business.ValidationRules.FluentValidation.FluentValidationRules
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{

			
			RuleFor(x => x.Email).Null().Must(MailKontrol).WithMessage("Mail Adresi Dolu olmalidir.");
		}

		private bool MailKontrol(string email)
		{
			if (String.IsNullOrEmpty(email))
			{
				if ((HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action") == "SignUp"))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
