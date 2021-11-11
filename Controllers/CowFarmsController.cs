using System.Collections.Generic;
using AutoMapper;
using DairyAPI.Data;
using DairyAPI.Dtos;
using DairyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DairyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowFarmsController : ControllerBase
    {
        private readonly ICowRepo _repository;
        private readonly IMapper _mapper;

        public CowFarmsController(ICowRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms()
        {
            var cows = _repository.GetAllCowFarms();
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m4")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age4m()
        {
            var cows = _repository.GetAllCowFarms_Age4m();
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m4/{aiZone}")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age4mByaiZone(string aiZone)
        {
            var cows = _repository.GetAllCowFarms_Age4mByaiZone(aiZone);
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m12")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age12m()
        {
            var cows = _repository.GetAllCowFarms_Age12m();
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m12/{aiZone}")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age12mByaiZone(string aiZone)
        {
            var cows = _repository.GetAllCowFarms_Age12mByaiZone(aiZone);
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m18")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age18m()
        {
            var cows = _repository.GetAllCowFarms_Age18m();
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }

        [Route("age/m18/{aiZone}")]
        [HttpGet]
        public ActionResult<IEnumerable<CowFarmsReadDto>> GetAllCowFarms_Age18mByaiZone(string aiZone)
        {
            var cows = _repository.GetAllCowFarms_Age18mByaiZone(aiZone);
            return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
        }
    }
}