using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CalveProfile : Profile
    {
        public CalveProfile()
        {
            CreateMap<Calve, CalveReadDto>();
        }
    }
}