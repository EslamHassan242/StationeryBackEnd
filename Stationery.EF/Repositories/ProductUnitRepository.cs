using Stationery.CORE.Interfaces;
using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.EF.Repositories
{
    public class ProductUnitRepository : BaseRepository<ProductUnits>, IProductUnitRepository
    {
        public ProductUnitRepository(ApplicationDbContext context) : base(context)
        {
        }
        public bool FindIfQuentityIsExist(int productId,int unitId,decimal quentity)
        {
            var productUnit = _context.ProductUnits.SingleOrDefault(p=> p.ProductId==productId && p.UnitId==unitId);
            if (productUnit.Quentity>=quentity)
                return true;
            else return false;
        }
    }
}
