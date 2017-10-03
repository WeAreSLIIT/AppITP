using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class GiftVoucherTypeRepository
	{
		IMS_DBContext ims = new IMS_DBContext();
		public List<GiftVoucherType> giftVoucherType()
		{
			return ims.GiftVoucherTypes.ToList();
		}
		public void InsertGiftVoucherType(GiftVoucherType giftVoucherType)
		{
			ims.GiftVoucherTypes.Add(giftVoucherType);
			ims.SaveChanges();
		}
		public void UpdateGiftVoucherType(GiftVoucherType giftVoucherType)
		{
			GiftVoucherType giftVoucherTypeUpdate = ims.GiftVoucherTypes.FirstOrDefault(x => x.voucherId == giftVoucherType.voucherId);
			giftVoucherTypeUpdate.name = giftVoucherType.name;
			giftVoucherTypeUpdate.amount = giftVoucherType.amount;
			giftVoucherTypeUpdate.description = giftVoucherType.description;
			giftVoucherTypeUpdate.noOfDays = giftVoucherType.noOfDays;

			ims.SaveChanges();
		}
		public void DeleteGiftVoucherType(GiftVoucherType giftVoucherType)
		{
			GiftVoucherType giftVoucherTypeDelete = ims.GiftVoucherTypes.FirstOrDefault(x => x.voucherId == giftVoucherType.voucherId);
			ims.GiftVoucherTypes.Remove(giftVoucherType);
			ims.SaveChanges();
		}
	}
}