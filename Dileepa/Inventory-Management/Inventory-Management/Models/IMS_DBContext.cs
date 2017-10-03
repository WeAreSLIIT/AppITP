using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Inventory_Management.Models.Discount
{
	public class IMS_DBContext : DbContext
	{
		public DbSet<DiscountType> DiscountTypes { get; set; }
		public DbSet<DiscountShedule> DiscountShedules { get; set; }
	}	
}
namespace Inventory_Management.Models.Promotion
{
	public class IMS_DBContext : DbContext
	{
		public DbSet<PromotionType> PromotionTypes { get; set; }
		public DbSet<PromotionShedule> PromotionShedules { get; set; }
	}
}

namespace Inventory_Management.Models.Voucher
{
	public class IMS_DBContext : DbContext
	{
		public DbSet<GiftVoucherType> GiftVoucherTypes { get; set; }
		public DbSet<IssueGiftVoucher> issueGiftVoucher { get; set; }
		public DbSet<RedeemGiftVoucher> redeemGiftVoucher { get; set; }

	}
}