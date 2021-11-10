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
        public ActionResult<IEnumerable<FarmReadDto>> GetAllFarms()
        {
            var farms = _repository.GetAllFarms();
            return Ok(_mapper.Map<IEnumerable<FarmReadDto>>(farms));
        }

        [HttpGet("{fFarmId}")]
        public ActionResult<FarmReadDto> GetFarmById(string fFarmId)
        {
            var farm = _repository.GetFarmById(fFarmId);
            if (farm != null)
            {
                return Ok(_mapper.Map<FarmReadDto>(farm));
            }
            return NotFound();
        }
    }
}