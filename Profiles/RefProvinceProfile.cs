using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class RefProvinceProfile : Profile
    {
        public RefProvinceProfile()
        {
            CreateMap<RefProvince, RefProvinceReadDto>();
        }
    }
}