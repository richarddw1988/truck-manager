using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Domain.Interfaces.Services;

namespace TruckManager.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(TEntity entidade)
        {
            _repository.Delete(entidade);
        }

        public virtual int Add(TEntity entidade)
        {
            return _repository.Add(entidade);
        }

        public virtual TEntity Find(int id)
        {
            return _repository.Find(id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _repository.All();
        }
    }
}
