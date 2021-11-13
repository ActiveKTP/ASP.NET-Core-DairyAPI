using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CalvingProfile : Profile
    {
        public CalvingProfile()
        {
            CreateMap<Calving, CalvingReadDto>();
        }
    }
}