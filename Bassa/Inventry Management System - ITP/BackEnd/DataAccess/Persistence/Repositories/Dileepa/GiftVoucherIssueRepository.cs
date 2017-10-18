using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class GiftVoucherIssueRepository : Repository<GiftVoucherIssue>, IGiftVoucherIssueRepository
    {
        private readonly new InventryMangementSystemDbContext _context;
        public GiftVoucherIssueRepository(InventryMangementSystemDbContext context) : base(context)
        {
            this._context = context;
        }

        //public bool IsValidEmailAddress(string email)
        //{
        //	try
        //	{
        //		var emailChecked = new System.Net.Mail.MailAddress(email);
        //		return true;
        //	}
        //	catch
        //	{
        //		return false;
        //	}
        //}

        //public bool IsMobileNumberValid(string mobileNumber)
        //{
        //	// parse the number
        //	var _mobileNumber = ParsedMobileNumber(mobileNumber);

        //	// check if it's the right length
        //	if (_mobileNumber.Length != 10)
        //	{
        //		return false;
        //	}

        //	// check if it contains non-numeric characters
        //	if (!Regex.IsMatch(_mobileNumber, @"^[0-9]{10}$"))
        //	{
        //		return false;
        //	}

        //	return true;
        //}

        //private string ParsedMobileNumber(string number)
        //{
        //	number = number.Replace("+", "");
        //	number = number.Replace(".", "");
        //	number = number.Replace(" ", "");
        //	number = number.Replace("-", "");
        //	number = number.Replace("/", "");
        //	number = number.Replace("(", "");
        //	number = number.Replace(")", "");

        //	number = number.Trim(new char[] { '0' });

        //	if (!number.StartsWith("07"))
        //	{
        //		number = "07" + number;
        //	}

        //	return number;
        //}
    }
}
