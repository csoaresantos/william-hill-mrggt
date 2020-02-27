using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MRGGT.Models;
using MRGGT.Persistence.Contexts;

namespace MRGGT.Repositories
{
    public class CustomRepository : BaseRepository, ICustomerRepository
    {
        public CustomRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> List()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Save(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            //_context.SaveChanges(); call in real database, not in memory data base.
        }
    }
}
