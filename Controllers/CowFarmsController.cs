using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms()
        {
            var cows = await _repository.GetAllCowFarms();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m4")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age4m()
        {
            var cows = await _repository.GetAllCowFarms_Age4m();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m4/{aiZone}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age4mByaiZone(string aiZone)
        {
            var cows = await _repository.GetAllCowFarms_Age4mByaiZone(aiZone);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m12")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age12m()
        {
            var cows = await _repository.GetAllCowFarms_Age12m();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m12/{aiZone}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age12mByaiZone(string aiZone)
        {
            var cows = await _repository.GetAllCowFarms_Age12mByaiZone(aiZone);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m18")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age18m()
        {
            var cows = await _repository.GetAllCowFarms_Age18m();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("age/m18/{aiZone}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age18mByaiZone(string aiZone)
        {
            var cows = await _repository.GetAllCowFarms_Age18mByaiZone(aiZone);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }
    }
}