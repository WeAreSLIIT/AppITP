using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Validation
{
    public class CustomerEmailAddress : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new
                RegularExpressionAttribute(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$")
                .IsValid(Convert.ToString(value).Trim());
        }
    }
}
