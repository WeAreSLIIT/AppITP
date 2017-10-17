using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DataAccess.Core.Validation
{
    public class PhoneNumber : ValidationAttribute
    {
        public bool IsValid(string value)
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
