using Stationery.CORE;
using Stationery.CORE.Interfaces;
using Stationery.CORE.Models;
using Stationery.EF.Repositories;
using Microsoft.AspNetCore.Http;

namespace Stationery.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IBaseRepository<Orders> Orders { get; private set; }
     
        //public IAccusedRepository Accused { get; }
        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //Kadia = new KadiaRepository(_context, _httpContextAccessor);

            Orders = new BaseRepository<Orders>(_context);
           
            
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