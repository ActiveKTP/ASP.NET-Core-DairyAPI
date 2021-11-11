using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowFarmsProfile : Profile
    {
        public CowFarmsProfile()
        {
            CreateMap<CowFarms, CowFarmsReadDto>();
        }
    }
}