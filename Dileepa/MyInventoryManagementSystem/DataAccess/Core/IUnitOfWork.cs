using System;
using DataAccess.Core.Repositories;

namespace DataAccess.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IDiscountScheduleRepository DiscountSchedules { get; }
		IDiscountTypeRepository DiscountTypes { get; }
		IGiftVoucherTypeRepository GiftVoucherTypes { get; }
		IGiftVoucherIssueRepository GiftVoucherIssues { get; }
		IPromotionTypeRepository PromotionTypes { get; }
		IPromotionScheduleRepository PromotionSchedules { get; }
		//IRedeemGiftVoucherRepository RedeemGiftVouchers { get; }

		int Complete();
	}
}
