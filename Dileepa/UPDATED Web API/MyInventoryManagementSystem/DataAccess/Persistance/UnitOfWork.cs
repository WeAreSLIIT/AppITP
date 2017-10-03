using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using DataAccess.Persistance.Repositories;

namespace DataAccess.Persistance
{
	public class UnitOfWork:IUnitOfWork
	{
		private readonly MyInventoryManagementSystemDbContext _context;


		public IDiscountScheduleRepository DiscountSchedules { get; private set; }
		public IDiscountTypeRepository DiscountTypes { get; private set; }
		public IGiftVoucherTypeRepository GiftVoucherTypes { get; private set; }
		public IGiftVoucherIssueRepository GiftVoucherIssues { get; private set; }
		public IPromotionTypeRepository PromotionTypes { get; private set; }
		public IPromotionScheduleRepository PromotionSchedules { get; private set; }
		//public IRedeemGiftVoucherRepository RedeemGiftVouchers { get; private set; }

		public UnitOfWork()
		{
			this._context = new MyInventoryManagementSystemDbContext();

			DiscountSchedules = new DiscountScheduleRepository(this._context);
			DiscountTypes = new DiscountTypeRepository(this._context);
			GiftVoucherTypes = new GiftVoucherTypeRepository(this._context);
			GiftVoucherIssues = new GiftVoucherIssueRepository(this._context);
			PromotionTypes = new PromotionTypeRepository(this._context);
			PromotionSchedules = new PromotionScheduleRepository(this._context);
			//RedeemGiftVouchers = new Repositories.RedeemGiftVoucherRepository(this._context);
		}

		public int Complete()
		{
			return this._context.SaveChanges();
		}
		public void Dispose()
		{
			this._context.Dispose();

		}
	}
}
