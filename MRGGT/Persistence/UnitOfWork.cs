using System;
using System.Threading.Tasks;
using MRGGT.Persistence.Contexts;
using MRGGT.Repositories;

namespace MRGGT.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAction()
        {
            await _context.SaveChangesAsync();
        }
    }
}
