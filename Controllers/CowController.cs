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
        public ActionResult<IEnumerable<CowReadDto>> GetAllCows()
        {
            var cows = _repository.GetAllCows();
            return Ok(_mapper.Map<IEnumerable<CowReadDto>>(cows));
        }

        [HttpGet("{ccowId}")]
        public ActionResult<CowReadDto> GetCowById(string ccowId)
        {
            var cow = _repository.GetCowById(ccowId);
            if (cow != null)
            {
                return Ok(_mapper.Map<CowReadDto>(cow));
                //return Ok(cow);
            }
            return NotFound();
        }
    }
}