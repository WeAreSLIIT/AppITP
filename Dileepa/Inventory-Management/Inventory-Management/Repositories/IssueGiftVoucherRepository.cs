using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Inventory_Management.Models.IRepositories;
using Inventory_Management.Models.Voucher;

namespace Inventory_Management.Repositories
{
	public class IssueGiftVoucherRepository : Repository<IssueGiftVoucher> , IIssueGiftVoucherRepository
	{
		public IssueGiftVoucherRepository(DbContext context) : base(context)
		{
		}
	}
}