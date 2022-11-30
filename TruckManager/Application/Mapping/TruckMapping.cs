using AutoMapper;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;

namespace TruckManager.Application.Mapping
{
    public class TruckMapping : Profile
    {
        public TruckMapping()
        {
            CreateMap<Truck, TruckViewModel>()
                .ForMember(m => m.IdModelo, s => s.MapFrom(f => f.Modelo.Id))
                .ForMember(m => m.Modelo, s => s.MapFrom(f => f.Modelo.Nome));
            CreateMap<TruckViewModel, Truck>()
                .ForMember(m => m.Modelo, s => s.Ignore());
        }
    }
}
