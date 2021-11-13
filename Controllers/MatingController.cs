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
    public class MatingController : ControllerBase
    {
        private readonly IMatingRepo _repository;
        private readonly IMapper _mapper;

        public MatingController(IMatingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatingReadDto>>> GetAllMating()
        {
            var mating = await _repository.GetAllMating();
            if (mating != null)
            {
                return Ok(_mapper.Map<IEnumerable<MatingReadDto>>(mating));
            }
            return NotFound();

        }

        [HttpGet("{maTranId}")]
        public async Task<ActionResult<MatingReadDto>> GetMatingByTranId(int maTranId)
        {
            var mating = await _repository.GetMatingByTranId(maTranId);
            if (mating != null)
            {
                return Ok(_mapper.Map<MatingReadDto>(mating));
            }
            return NotFound();
        }
    }
}