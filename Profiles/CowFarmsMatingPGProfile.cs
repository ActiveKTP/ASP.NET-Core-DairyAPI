using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class CowFarmsMatingPGProfile : Profile
    {
        public CowFarmsMatingPGProfile()
        {
            CreateMap<CowFarmsMatingPG, CowFarmsMatingPGReadDto>();
        }
    }
}