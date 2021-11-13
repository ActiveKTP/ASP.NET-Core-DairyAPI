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
    public class CalvingController : ControllerBase
    {
        private readonly ICalvingRepo _repository;
        private readonly IMapper _mapper;

        public CalvingController(ICalvingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalvingReadDto>>> GetAllCalving()
        {
            var calving = await _repository.GetAllCalving();
            if (calving != null)
            {
                return Ok(_mapper.Map<IEnumerable<CalvingReadDto>>(calving));
            }
            return NotFound();

        }

        [HttpGet("{cvgTranId}")]
        public async Task<ActionResult<CalvingReadDto>> GetCalvingBycvgTranId(int cvgTranId)
        {
            var calving = await _repository.GetCalvingBycvgTranId(cvgTranId);
            if (calving != null)
            {
                return Ok(_mapper.Map<CalvingReadDto>(calving));
            }
            return NotFound();
        }
    }
}