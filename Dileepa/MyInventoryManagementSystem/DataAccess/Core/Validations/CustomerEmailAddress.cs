using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;

namespace DataAccess.Core.Validations
{
	class CustomerEmailAddress : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			return new
				RegularExpressionAttribute(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$")
				.IsValid(Convert.ToString(value).Trim());
		}
	}
}
