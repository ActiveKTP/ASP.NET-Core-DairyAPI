using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowProfile : Profile
    {
        public CowProfile()
        {
            CreateMap<Cow, CowReadDto>();
        }
    }
}