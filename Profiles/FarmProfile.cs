using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class FarmProfile : Profile
    {
        public FarmProfile()
        {
            CreateMap<Farm, FarmReadDto>();
        }
    }
}