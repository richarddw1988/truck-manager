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
    public class ModeloRepository : RepositoryBase<Modelo>, IModeloRepository
    {
        public ModeloRepository(TruckManagerContext context)
            : base(context)
        {
        }
    }
}
