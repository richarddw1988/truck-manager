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
    public class TruckService : ServiceBase<Truck>, ITruckService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly ITruckRepository _repository;
        public TruckService(ITruckRepository repository, IModeloRepository modeloRepository)
           : base(repository)
        {
            _repository = repository;
            _modeloRepository = modeloRepository;
        }

        public override IEnumerable<Truck> All()
        {
            return _repository.AllCustom();
        }

        public override int Add(Truck truck)
        {
            Modelo modelo = _modeloRepository.Find(truck.IdModelo);
            bool isAnoFabricaoIgualAnoAtual = truck.IsAnoFabricacaoIgualAnoAtual();
            bool isAnoModeloIgualAnoAtual = truck.IsAnoModeloIgualAnoAtual();
            bool isAnoModeloIgualAnoSubsequente = truck.IsAnoModeloIgualAnoSubsequente();

            if (!modelo.Ativo)
            {
                throw new ArgumentException("O modelo informado ao inserir está inativo.");
            }

            if (!isAnoFabricaoIgualAnoAtual)
            {
                throw new ArgumentException("O ano de fabricação informado ao inserir deve ser o ano atual.");
            }

            if (!isAnoModeloIgualAnoAtual && !isAnoModeloIgualAnoSubsequente)
            {
                throw new ArgumentException("O ano do modelo informado ao inserir deve ser o ano atual ou o subsequente.");
            }

            return base.Add(truck);
        }

        public override void Update(Truck truck)
        {
            Modelo modelo = _modeloRepository.Find(truck.IdModelo);
            bool isAnoFabricaoIgualAnoAtual = truck.IsAnoFabricacaoIgualAnoAtual();
            bool isAnoModeloIgualAnoAtual = truck.IsAnoModeloIgualAnoAtual();
            bool isAnoModeloIgualAnoSubsequente = truck.IsAnoModeloIgualAnoSubsequente();
            
            if (!modelo.Ativo)
            {
                throw new ArgumentException("O modelo informado ao atualizar está inativo.");
            }

            if (!isAnoFabricaoIgualAnoAtual)
            {
                throw new ArgumentException("O ano de fabricação informado ao atualizar deve ser o ano atual.");
            }

            if (!isAnoModeloIgualAnoAtual && !isAnoModeloIgualAnoSubsequente)
            {
                throw new ArgumentException("O ano do modelo informado ao atualizar deve ser o ano atual ou o subsequente.");
            }

            base.Update(truck);
        }
    }
}
