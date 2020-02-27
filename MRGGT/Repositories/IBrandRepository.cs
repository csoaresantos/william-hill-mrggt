using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRGGT.Models;

namespace MRGGT.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> List();
        Task<Brand> FindById(int id);
    }
}
