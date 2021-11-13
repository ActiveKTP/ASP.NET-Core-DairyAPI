using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class GrowthProfile : Profile
    {
        public GrowthProfile()
        {
            CreateMap<Growth, GrowthReadDto>();
        }
    }
}