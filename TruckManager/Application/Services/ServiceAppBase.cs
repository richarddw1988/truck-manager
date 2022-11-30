using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Application.Interfaces;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Services;

namespace TruckManager.Application.Services
{
    public class ServiceAppBase<TEntity, TViewModel> : IAppBase<TEntity, TViewModel>
        where TEntity : EntityBase
        where TViewModel : ViewModelBase
    {
        protected readonly IServiceBase<TEntity> _service;
        protected readonly IMapper _mapper;

        public ServiceAppBase(IMapper mapper, IServiceBase<TEntity> service)
            : base()
        {
            _mapper = mapper;
            _service = service;
        }

        public virtual void Update(TViewModel entidade)
        {
            _service.Update(_mapper.Map<TEntity>(entidade));
        }

        public virtual void Delete(int id)
        {
            _service.Delete(id);
        }

        public virtual void Delete(TViewModel entidade)
        {
            _service.Delete(_mapper.Map<TEntity>(entidade));
        }

        public virtual int Add(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            return _service.Add(entity);
        }

        public virtual TViewModel Find(int id)
        {
            return _mapper.Map<TViewModel>(_service.Find(id));
        }

        public virtual IEnumerable<TViewModel> All()
        {
            return _mapper.Map<IEnumerable<TViewModel>>(_service.All());
        }
    }
}
