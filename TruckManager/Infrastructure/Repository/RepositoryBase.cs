using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Infrastructure.Context;

namespace TruckManager.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly TruckManagerContext _context;

        public RepositoryBase(TruckManagerContext context)
            : base()
        {
            _context = context;
        }

        public int Add(TEntity entity)
        {
            _context.InitTransacao();
            var id = _context.Set<TEntity>().Add(entity).Entity.Id;
            _context.SendChanges();
            return id;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            if (entity != null)
            {
                _context.InitTransacao();
                _context.Set<TEntity>().Remove(entity);
                _context.SendChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            _context.InitTransacao();
            _context.Set<TEntity>().Remove(entity);
            _context.SendChanges();
        }

        public TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.InitTransacao();
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SendChanges();
        }
    }
}
