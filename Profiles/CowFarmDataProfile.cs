using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowFarmDataProfile : Profile
    {
        public CowFarmDataProfile()
        {
            CreateMap<CowFarmData, CowFarmDataReadDto>();
        }
    }
}