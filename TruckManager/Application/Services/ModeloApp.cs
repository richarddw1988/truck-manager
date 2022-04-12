using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Services;

namespace TruckManager.Application.Services
{
    public class ModeloApp : ServiceAppBase<Modelo, ModeloViewModel>
    {
        public ModeloApp(IMapper mapper, IModeloService service) : base(mapper, service)
        {
        }
    }
}
