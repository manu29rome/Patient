using Microsoft.AspNetCore.Mvc;
using Patent.Application.Interfaces;
using Patent.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Patent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatentController(IPatentService patentService) : ControllerBase
    {
        // GET: api/<PatentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await patentService.GetListParent());
        }

        // POST api/<PatentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientEntity value)
        {
            return Ok();
        }

        // POST api/<PatentController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PatientEntity value)
        {
            return Ok();
        }


    }
}
