using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
	public interface IDiscountScheduleRepository : IRepository<DiscountSchedule>
	{
		float PriceWithDiscount(float OriginalPrice, DiscountMethod status, float DiscountAmount);
		//IEnumerable<DiscountSchedule>GetTopDiscount(int ID);
		///*DiscountSchedule GetDiscountById(int id)*/
		//IEnumerable<DiscountSchedule> GetAllDiscounts();
		////int InsertDiscount(DiscountSchedule productEntity);
		////bool UpdateDiscount(int Id, DiscountSchedule discount);
		//bool DeleteDiscount(int Id);
	}
}
