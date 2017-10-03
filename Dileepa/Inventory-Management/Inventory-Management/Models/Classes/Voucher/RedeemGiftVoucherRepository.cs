using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class RedeemGiftVoucherRepository
	{
		IMS_DBContext ims = new IMS_DBContext();
		public List<RedeemGiftVoucher> redeemGiftVoucher()
		{
			return ims.redeemGiftVoucher.ToList();
		}
		public void InsertRedeemGiftVoucher(RedeemGiftVoucher redeemGiftVoucher)
		{
			ims.redeemGiftVoucher.Add(redeemGiftVoucher);
			ims.SaveChanges();
		}
	}
}