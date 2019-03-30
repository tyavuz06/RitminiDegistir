using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Takas.Entities.Concrete;

namespace Takas.Business.ValidationRules.FluentValidation.FluentValidationRules
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Address).MaximumLength(255).NotEmpty().OnFailure(RMA);
			RuleFor(x => x.ID).NotEmpty().WithMessage("Ups Bu Alan Bos Olamaz");
		
		}

		private void RMA(Product obj)
		{
			throw new NotImplementedException();
		}
	}
}
