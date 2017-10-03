using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
	public interface IGiftVoucherIssueRepository : IRepository<GiftVoucherIssue>
	{
		////bool IsValidEmailAddress(string email);
		////bool IsMobileNumberValid(string mobileNumber);
	}
}
