﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core
{
    public enum ProductType : byte
    {
        Unit,
        Measurable
    }

    public enum DatabaseTable : byte
    {
        Product = 1,
        PaymentMethod
    }
}
