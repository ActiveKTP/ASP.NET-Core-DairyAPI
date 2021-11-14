using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowFarmsGrowthProfile : Profile
    {
        public CowFarmsGrowthProfile()
        {
            CreateMap<CowFarmsGrowth, CowFarmsGrowthReadDto>();
        }
    }
}