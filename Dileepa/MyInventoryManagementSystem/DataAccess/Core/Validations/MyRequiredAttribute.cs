using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Validations
{
	class MyRequiredAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var Required=new MyRequiredAttribute();
			return Required.IsValid(Convert.ToString(value).Trim());
		}
	}
}
