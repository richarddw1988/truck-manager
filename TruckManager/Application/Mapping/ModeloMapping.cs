using AutoMapper;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;

namespace TruckManager.Application.Mapping
{
    public class ModeloMapping : Profile
    {
        public ModeloMapping()
        {
            CreateMap<Modelo, ModeloViewModel>();
            CreateMap<ModeloViewModel, Modelo>();
        }
    }
}
