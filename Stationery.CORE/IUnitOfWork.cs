﻿using Stationery.CORE.Interfaces;
using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Orders> Orders { get;  }
        IBaseRepository<OrdersDetails> OrderDetails { get; }
        public IProductUnitRepository ProductUnits { get; }

        int Complete();
    }
}