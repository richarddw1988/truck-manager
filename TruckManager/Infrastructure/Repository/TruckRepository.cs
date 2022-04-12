using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace TruckManager.Infrastructure.Repository
{
    public class TruckRepository : RepositoryBase<Truck>, ITruckRepository
    {
        public TruckRepository(TruckManagerContext context)
            : base(context)
        {
        }

        public IEnumerable<Truck> AllCustom()
        {
            //Não estava mapeando o primeiro modelo da lista então tive que fazer isso
            var query = from t in _context.Truck
                        join m in _context.Modelo on t.IdModelo equals m.Id
                        select new Truck()
                        {
                            Id = t.Id,
                            AnoFabricacao = t.AnoFabricacao,
                            AnoModelo = t.AnoModelo,
                            IdModelo = t.IdModelo,
                            Nome = t.Nome,
                            Modelo = new Modelo()
                            {
                                Id = m.Id,
                                Nome = m.Nome,
                                Ativo = m.Ativo
                            }
                        };

            var trucks = query.ToList();
            return trucks;
        }
    }
}
