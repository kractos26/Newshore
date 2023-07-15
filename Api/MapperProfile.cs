using AutoMapper;
using DataAcess.Models;
using Dto;

namespace Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DtoFlight, Flight>();
            CreateMap<DtoJourney, Journey>();
            CreateMap<DtoTransport, Transport>();
            CreateMap<Transport,DtoTransport>();
            CreateMap<Flight, DtoFlight>();
            CreateMap<Journey, DtoJourney>();
        }
    }
}
