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
    public class FarmController : ControllerBase
    {
        private readonly IFarmRepo _repository;
        private readonly IMapper _mapper;

        public FarmController(IFarmRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmReadDto>>> GetAllFarms()
        {
            var farms = await _repository.GetAllFarms();
            if (farms != null)
            {
                return Ok(_mapper.Map<IEnumerable<FarmReadDto>>(farms));
            }
            return NotFound();
        }

        [HttpGet("{fFarmId}")]
        public async Task<ActionResult<FarmReadDto>> GetFarmById(string fFarmId)
        {
            var farm = await _repository.GetFarmById(fFarmId);
            if (farm != null)
            {
                return Ok(_mapper.Map<FarmReadDto>(farm));
            }
            return NotFound();
        }
    }
}