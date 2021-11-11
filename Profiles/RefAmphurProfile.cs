using AutoMapper;
using DairyAPI.Dtos;
using DairyAPI.Models;

namespace DairyAPI.Profiles
{
    public class RefAmphurProfile : Profile
    {
        public RefAmphurProfile()
        {
            CreateMap<RefAmphur, RefAmphurReadDto>();
        }
    }
}