using AutoMapper;
using CarsNotes.Core.DTOs;
using CarsNotes.Web.Models;

namespace CarsNotes.Web.Mappings
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<CarDto, CarViewModel>().ReverseMap();

            CreateMap<CarInfoDto, CarInfoViewModel>().ReverseMap();
        }
    }
}
