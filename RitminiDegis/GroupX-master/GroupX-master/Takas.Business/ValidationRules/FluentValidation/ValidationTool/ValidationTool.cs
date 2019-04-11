using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Takas.Business.ValidationRules.FluentValidation.ValidationTool
{
	public static class ValidationTool
	{
		public static void Validate(IValidator _validator, object entity)
		{
			var result = _validator.Validate(entity); // Kontrolunu sagliyoruz
		
			if (result.Errors.Count > 0) // Eger result in icndeki hatalar 0 dan buyukse hata var demektir. Eger Buyuk degilse demekki hata yoktur,
			{
				throw new ValidationException(result.Errors);

			}
		}
	}
}
