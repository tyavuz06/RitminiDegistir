﻿using System;
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
			RuleFor(x => x.Email).Null();
		}

		
	}
}
