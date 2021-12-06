using System;
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
    public class CowController : ControllerBase
    {
        private readonly ICowRepo _repository;
        private readonly IMapper _mapper;

        public CowController(ICowRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowReadDto>>> GetAllCows()
        {
            var cows = await _repository.GetAllCows();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowReadDto>>(cows));
            }
            return NotFound();

        }

        [HttpGet("{ccowId}")]
        public async Task<ActionResult<CowReadDto>> GetCowById(string ccowId)
        {
            var cow = await _repository.GetCowById(ccowId);
            if (cow != null)
            {
                return Ok(_mapper.Map<CowReadDto>(cow));
                //return Ok(cow);
            }
            return NotFound();
        }

        [Route("farm")]
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

        [Route("farm/{ccowId}")]
        [HttpGet]
        public async Task<ActionResult<CowFarmDataReadDto>> GetCowDataById(string ccowId)
        {
            var cow = await _repository.GetCowDataById(ccowId);
            if (cow != null)
            {
                return Ok(_mapper.Map<CowFarmDataReadDto>(cow));
            }
            return NotFound();
        }

        [Route("farm/age/{age}/{aiZone}/{startDate}/{endDate}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age(int age, string aiZone, string startDate, string endDate)
        {
            DateTime newstartDate = DateTime.Parse(startDate);
            DateTime newendDate = DateTime.Parse(endDate);
            var cows = await _repository.GetAllCowFarms_Age(age, aiZone, newstartDate, newendDate);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("farm/age/m4")]
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

        [Route("farm/age/m4/{aiZone}")]
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

        [Route("farm/age/m4/{aiZone}/{startDate}/{endDate}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age4mByaiZone_setDate(string aiZone, string startDate, string endDate)
        {
            DateTime newstartDate = DateTime.Parse(startDate);
            DateTime newendDate = DateTime.Parse(endDate);
            var cows = await _repository.GetAllCowFarms_Age4mByaiZone_setDate(aiZone, newstartDate, newendDate);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("farm/age/m12")]
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

        [Route("farm/age/m12/{aiZone}")]
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

        [Route("farm/age/m12/{aiZone}/{startDate}/{endDate}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age12mByaiZone_setDate(string aiZone, string startDate, string endDate)
        {
            DateTime newstartDate = DateTime.Parse(startDate);
            DateTime newendDate = DateTime.Parse(endDate);
            var cows = await _repository.GetAllCowFarms_Age12mByaiZone_setDate(aiZone, newstartDate, newendDate);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("farm/age/m18")]
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

        [Route("farm/age/m18/{aiZone}")]
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

        [Route("farm/age/m18/{aiZone}/{startDate}/{endDate}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsReadDto>>> GetAllCowFarms_Age18mByaiZone_setDate(string aiZone, string startDate, string endDate)
        {
            DateTime newstartDate = DateTime.Parse(startDate);
            DateTime newendDate = DateTime.Parse(endDate);
            var cows = await _repository.GetAllCowFarms_Age18mByaiZone_setDate(aiZone, newstartDate, newendDate);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("farm/mating/pg")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsMatingPGReadDto>>> GetAllCowFarmsMatingPG()
        {
            var cows = await _repository.GetAllCowFarmsMatingPG();
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsMatingPGReadDto>>(cows));
            }
            return NotFound();
        }

        [Route("farm/mating/pg/{aiZone}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsMatingPGReadDto>>> GetAllCowFarmsMatingPGByaiZone(string aiZone)
        {
            var cows = await _repository.GetAllCowFarmsMatingPGByaiZone(aiZone);
            if (cows != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsMatingPGReadDto>>(cows));
            }
            return NotFound();
        }
    }
}