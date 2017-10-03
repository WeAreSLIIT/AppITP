using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Core.Validations
{
	class PhoneNumber : ValidationAttribute
	{
		public  bool IsValid(string value)
		{
			var PhoneNum = ParsedMobileNumber(value);
			if (PhoneNum.Length != 10)
			{
				return false;
			}
			if (!Regex.IsMatch(PhoneNum, @"^[0-9]{9}$"))
			{
				return false;
			}

			return true;
		}

		private string ParsedMobileNumber(string number)
		{
			number = number.Replace("+", "");
			number = number.Replace(".", "");
			number = number.Replace(" ", "");
			number = number.Replace("-", "");
			number = number.Replace("/", "");
			number = number.Replace("(", "");
			number = number.Replace(")", "");

			number = number.TrimStart(new char[] { '0' });

			if (!number.StartsWith("07"))
			{
				number = "07" + number;
			}

			return number;
		}
	}
}
