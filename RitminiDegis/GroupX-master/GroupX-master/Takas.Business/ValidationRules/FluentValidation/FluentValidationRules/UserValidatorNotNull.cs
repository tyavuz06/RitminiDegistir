using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Takas.Common.Entities.Concrete;

namespace Takas.Business.ValidationRules.FluentValidation.FluentValidationRules
{
	public class UserValidatorNotNull : AbstractValidator<User>
	{
		public UserValidatorNotNull()
		{
			RuleFor(x => x.Email).NotNull();
		}
	}
}
