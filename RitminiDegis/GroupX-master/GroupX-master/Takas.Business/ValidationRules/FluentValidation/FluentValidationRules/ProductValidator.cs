using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Takas.Common.Entities.Concrete;


namespace Takas.Business.ValidationRules.FluentValidation.FluentValidationRules
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{

		//	RuleFor(x => x.Email).NotNull().When(x=>x.)
		}

		

	}
}
