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
    public class TruckApp : ServiceAppBase<Truck, TruckViewModel>
    {
        public TruckApp(IMapper mapper, ITruckService service) : base(mapper, service)
        {
        }

        public override void Delete(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException("Favor selecionar o registro para ser excluído.");
            }
            base.Delete(id);
        }

        public override void Update(TruckViewModel truckViewModel)
        {
            if(!truckViewModel.Id.HasValue || truckViewModel.Id == 0)
            {
                throw new ArgumentException("Favor selecionar o registro para ser atualizado.");
            }

            if(string.IsNullOrWhiteSpace(truckViewModel.Nome) || !truckViewModel.IdModelo.HasValue || truckViewModel.IdModelo == 0 || !truckViewModel.AnoModelo.HasValue || truckViewModel.AnoModelo == 0 || !truckViewModel.AnoFabricacao.HasValue || truckViewModel.AnoFabricacao == 0)
            {
                throw new ArgumentException("Favor preencher todos os campos para atualizar o modelo.");
            }

            base.Update(truckViewModel);
        }

        public override int Add(TruckViewModel truckViewModel)
        {
            if (string.IsNullOrWhiteSpace(truckViewModel.Nome) || !truckViewModel.IdModelo.HasValue || truckViewModel.IdModelo == 0 || !truckViewModel.AnoModelo.HasValue || truckViewModel.AnoModelo == 0 || !truckViewModel.AnoFabricacao.HasValue || truckViewModel.AnoFabricacao == 0)
            {
                throw new ArgumentException("Favor preencher todos os campos para incluir um novo modelo.");
            }

            return base.Add(truckViewModel);
        }
    }
}
