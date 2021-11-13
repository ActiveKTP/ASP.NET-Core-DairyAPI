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
    }
}