using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DairyAPI.Data;
using DairyAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DairyAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GrowthController : ControllerBase
    {
        private readonly IGrowthRepo _repository;
        private readonly IMapper _mapper;

        public GrowthController(IGrowthRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrowthReadDto>>> GetAllGrowth()
        {
            var growths = await _repository.GetAllGrowth();
            if (growths != null)
            {
                return Ok(_mapper.Map<IEnumerable<GrowthReadDto>>(growths));
            }
            return NotFound();

        }

        [HttpGet("{gTranId}")]
        public async Task<ActionResult<GrowthReadDto>> GetGrowthBygTranId(int gTranId)
        {
            var growth = await _repository.GetGrowthBygTranId(gTranId);
            if (growth != null)
            {
                return Ok(_mapper.Map<GrowthReadDto>(growth));
            }
            return NotFound();
        }

        [Route("farm/cow/{type}/{aiZone}/{year}/{month}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsGrowthReadDto>>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month)
        {
            int m, y;
            if (type == "01") { m = month - 4; }
            else if (type == "02") { m = month - 12; }
            else if (type == "03") { m = month - 18; }
            else { m = month; }
            y = year;
            if (m < 1)
            {
                m = 12 + m;
                y = y - 1;
            }
            var growth = await _repository.GetAllCowFarmsGrowth_type_aiZone(type, aiZone, y, m);
            if (growth != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsGrowthReadDto>>(growth));
            }
            return NotFound();
        }

        [Route("farm/cow/cv/{aiZone}/{year}/{month}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CowFarmsGrowthCVReadDto>>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month)
        {
            var growth = await _repository.GetAllCowFarmsGrowthCV_aiZone(aiZone, year, month);
            if (growth != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsGrowthCVReadDto>>(growth));
            }
            return NotFound();
        }
    }
}