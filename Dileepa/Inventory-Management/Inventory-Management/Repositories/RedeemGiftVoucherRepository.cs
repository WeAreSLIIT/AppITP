using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_Management.Models.IRepositories;
using Inventory_Management.Models.Voucher;

namespace Inventory_Management.Repositories
{
	public class RedeemGiftVoucherRepository : Repository<RedeemGiftVoucher>, IRedeemGiftVoucherRepository
	{
		public RedeemGiftVoucherRepository(DbContext context) : base(context)
		{
		}
	}
}