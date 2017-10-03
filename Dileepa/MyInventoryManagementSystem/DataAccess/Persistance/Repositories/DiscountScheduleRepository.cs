using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistance.Repositories
{
	public class DiscountScheduleRepository : Repository<DiscountSchedule>, IDiscountScheduleRepository
	{
		private readonly new MyInventoryManagementSystemDbContext _context;

		public DiscountScheduleRepository(MyInventoryManagementSystemDbContext Context) : base(Context)
		{
			this._context = Context;
		}
		public float PriceWithDiscount(float OriginalPrice, DiscountMethod status, float DiscountAmount)
		{

			if (status == DiscountMethod.fixedPrice)
			{
				float PriceWithDiscount = OriginalPrice - DiscountAmount;
				return PriceWithDiscount;

			}
			else
			{
				float PriceWithDiscount = OriginalPrice - ((OriginalPrice * DiscountAmount) / 100);
				return PriceWithDiscount;
			}


		}
		//Enumerable<DiscountSchedule> GetTopDiscount(int ID)
		//{
		//	return this._context.DiscountShedules.O
		//}

		//public bool DeleteDiscount(int id)
		//{
		//	return this._context.DiscountShedules.SingleOrDefault(c => c.DiscountSheduleId == id);
		//	return false;

		//}

		//public DiscountSchedule GetDiscountTypeById(int ID)
		//{
		//	return this._context.DiscountShedules.SingleOrDefault(e=>e.DiscountSheduleId==ID);
		//}

		//void UpdateDiscount()
	}
}
