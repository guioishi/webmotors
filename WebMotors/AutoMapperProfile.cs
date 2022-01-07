using AutoMapper;

namespace WebMotors
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Core.Entities.Advertisement, Core.DTOs.GetAdvertisementDto>();
            CreateMap<Core.DTOs.GetAdvertisementDto, Core.Entities.Advertisement>();
            CreateMap<Core.DTOs.AddAdvertisementDto, Core.Entities.Advertisement>();
            CreateMap<Core.DTOs.UpdateAdvertisementDto, Core.Entities.Advertisement>();
        }
    }
}
