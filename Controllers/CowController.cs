using System.Collections.Generic;
using DairyAPI.Data;
using DairyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DairyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowController : ControllerBase
    {
        private readonly ICowRepo _repository;

        public CowController(ICowRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cow>> GetAllCows()
        {
            var cowlist = _repository.GetAllCows();
            return Ok(cowlist);
        }

        [HttpGet("{ccowId}")]
        public ActionResult<Cow> GetCowById(string ccowId)
        {
            var cowlist = _repository.GetCowById(ccowId);
            return Ok(cowlist);
        }
    }
}