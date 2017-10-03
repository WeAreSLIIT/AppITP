﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistance.Repositories
{
	public class PromotionScheduleRepository : Repository<PromotionSchedule>,IPromotionScheduleRepository
	{
		public PromotionScheduleRepository(MyInventoryManagementSystemDbContext context) : base(context)
		{

		}
	}
}
