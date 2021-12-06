using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DairyAPI.Data;
using DairyAPI.Dtos;
using DairyAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DairyAPI.Controllers
{
    [Route("api/[Controller]")]
    [EnableCors("AllowAnyOrigin")]
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

        [HttpGet("cow/{type}/{ccowId}")]
        public async Task<ActionResult<CowFarmsGrowthReadDto>> GetGrowthByCowId_gStatus(string ccowId, string type)
        {
            var growth = await _repository.GetGrowthByCowId_gStatus(ccowId, type);
            if (growth != null)
            {
                return Ok(_mapper.Map<CowFarmsGrowthReadDto>(growth));
            }
            return NotFound();
        }

        [HttpGet("cow/cv/{type}/{ccowId}")]
        public async Task<ActionResult<CowFarmsGrowthCVReadDto>> GetGrowth_CVByCowId_gStatus(string ccowId, string type)
        {
            var growth = await _repository.GetGrowth_CVByCowId_gStatus(ccowId, type);
            if (growth != null)
            {
                return Ok(_mapper.Map<CowFarmsGrowthCVReadDto>(growth));
            }
            return NotFound();
        }

        //[Route("farm/cow/{type}/{aiZone}/{year}/{month}")]
        [HttpGet("farm/cow/{type}/{aiZone}/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<CowFarmsGrowthReadDto>>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month, int _start, int _limit)
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
            var growth = await _repository.GetAllCowFarmsGrowth_type_aiZone(type, aiZone, y, m, _start, _limit);
            if (growth != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsGrowthReadDto>>(growth));
            }
            return NotFound();
        }

        //[Route("farm/cow/cv/{aiZone}/{year}/{month}")]
        [HttpGet("farm/cow/cv/{aiZone}/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<CowFarmsGrowthCVReadDto>>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month, int _start, int _limit)
        {
            var growth = await _repository.GetAllCowFarmsGrowthCV_aiZone(aiZone, year, month, _start, _limit);
            if (growth != null)
            {
                return Ok(_mapper.Map<IEnumerable<CowFarmsGrowthCVReadDto>>(growth));
            }
            return NotFound();
        }

        //Post api/growth
        [HttpPost]
        public async Task<ActionResult<GrowthReadDto>> CreateGrowth([FromBody] GrowthCreateDto growthCreateDto)
        {
            var growthModel = _mapper.Map<Growth>(growthCreateDto);
            var newGrowth = await _repository.CreateGrowth(growthModel);
            //_repository.SaveChanges();

            //var growthReadDto = _mapper.Map<GrowthReadDto>(growthModel);

            return CreatedAtAction(nameof(GetGrowthBygTranId), new { gTranId = newGrowth.gTranId }, newGrowth);
        }

        [HttpPut("{gTranId}")]
        public async Task<ActionResult> UpdateGrowths(int gTranId, [FromBody] GrowthUpdateDto growthUpdateDto)
        {
            if (gTranId != growthUpdateDto.gTranId)
            {
                return BadRequest();
            }

            var growthToUpdate = await _repository.GetGrowthBygTranId(gTranId);
            if (growthToUpdate == null)
            {
                return NotFound();
            }

            //var growthModel = _mapper.Map<Growth>(growthUpdateDto);
            _mapper.Map(growthUpdateDto, growthToUpdate);
            await _repository.Update(growthToUpdate);

            return NoContent();
        }

        [HttpDelete("{gTranId}")]
        public async Task<ActionResult> Delete(int gTranId)
        {
            var growthToDelete = await _repository.GetGrowthBygTranId(gTranId);
            if (growthToDelete == null)
            {
                return NotFound();
            }

            await _repository.Delete(growthToDelete);
            return NoContent();
        }
    }
}