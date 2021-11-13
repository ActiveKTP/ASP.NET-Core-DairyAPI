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
    public class CalveController : ControllerBase
    {
        private readonly ICalveRepo _repository;
        private readonly IMapper _mapper;

        public CalveController(ICalveRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalveReadDto>>> GetAllCalve()
        {
            var calve = await _repository.GetAllCalve();
            if (calve != null)
            {
                return Ok(_mapper.Map<IEnumerable<CalveReadDto>>(calve));
            }
            return NotFound();

        }

        [HttpGet("{cvgTranId}")]
        public async Task<ActionResult<CalveReadDto>> GetCalveBycvgTranId(int cvgTranId)
        {
            var calve = await _repository.GetCalveBycvgTranId(cvgTranId);
            if (calve != null)
            {
                return Ok(_mapper.Map<CalveReadDto>(calve));
            }
            return NotFound();
        }
    }
}