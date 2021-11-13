using AutoMapper;
using DairyAPI.Data;
using DairyAPI.Dtos;

namespace DairyAPI.Profiles
{
    public class MatingProfile : Profile
    {
        public MatingProfile()
        {
            CreateMap<Mating, MatingReadDto>();
        }
    }
}