using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowFarmsGrowthCVProfile : Profile
    {
        public CowFarmsGrowthCVProfile()
        {
            CreateMap<CowFarmsGrowthCV, CowFarmsGrowthCVReadDto>();
        }
    }
}