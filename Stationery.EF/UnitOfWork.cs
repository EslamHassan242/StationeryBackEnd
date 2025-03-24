using Stationery.CORE;
using Stationery.CORE.Interfaces;
using Stationery.CORE.Models;
using Stationery.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Stationery.CORE.consts;

namespace Stationery.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IBaseRepository<Orders> Orders { get; private set; }

        public IBaseRepository<OrdersDetails> OrderDetails { get; private set; }
        public IBaseRepository<Suppliers> Suppliers { get; private set; }
        public  IBaseRepository<Products> Products { get; private set; }
        public  IBaseRepository<OrdersBuy> OrderBuy { get; private set; }



        public IProductUnitRepository ProductUnits { get; }
      
        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //Kadia = new KadiaRepository(_context, _httpContextAccessor);

            Orders = new BaseRepository<Orders>(_context);
            OrderDetails = new BaseRepository<OrdersDetails>(_context);
            Suppliers = new BaseRepository<Suppliers>(_context);
            Products = new BaseRepository<Products>(_context);
            OrderBuy = new BaseRepository<OrdersBuy>(_context);
            


            ProductUnits = new ProductUnitRepository(_context);
          


        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}