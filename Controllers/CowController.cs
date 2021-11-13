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
    }
}