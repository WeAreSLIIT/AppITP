﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_Management.Models.IRepositories;
using Inventory_Management.Models.Promotion;

namespace Inventory_Management.Repositories
{
	public class PromotionTypeRepository : Repository<PromotionType>,IPromotionTypeRepository
	{
		public PromotionTypeRepository(DbContext context) : base(context)
		{
		}
	}
}