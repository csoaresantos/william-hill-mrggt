using System;
using System.Threading.Tasks;

namespace MRGGT.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAction();
    }
}
