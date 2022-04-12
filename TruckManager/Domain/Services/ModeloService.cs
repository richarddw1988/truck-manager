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
    public class ModeloService : ServiceBase<Modelo>, IModeloService
    {
        public ModeloService(IModeloRepository repositorio)
           : base(repositorio)
        {

        }
    }
}
