using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class IssueGiftVoucherRepository
	{
		IMS_DBContext ims = new IMS_DBContext();
		public List<IssueGiftVoucher> issueGiftVoucher()
		{
			return ims.issueGiftVoucher.ToList();
		}
		public void InsertIssueGiftVoucher(IssueGiftVoucher issueGiftVoucher)
		{
			ims.issueGiftVoucher.Add(issueGiftVoucher);
			ims.SaveChanges();
		}
	}
}