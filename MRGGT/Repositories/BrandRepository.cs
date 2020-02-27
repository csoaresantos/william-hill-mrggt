using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MRGGT.Models;
using MRGGT.Persistence.Contexts;

namespace MRGGT.Repositories
{
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        public BrandRepository(AppDbContext context):base(context){}

        public Task<Brand> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> List()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
