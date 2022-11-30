using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;

namespace TruckManager.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Add(TEntity entidade);
        void Delete(int id);
        void Delete(TEntity entidade);
        void Update(TEntity entidade);
        TEntity Find(int id);
        IEnumerable<TEntity> All();
    }
}
