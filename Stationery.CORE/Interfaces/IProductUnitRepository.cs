using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Interfaces
{
    public interface IProductUnitRepository : IBaseRepository<ProductUnits>
    {
        bool FindIfQuentityIsExist(int productId, int unitId, decimal quentity);
    }
}
