using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TawredatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderApiController : ControllerBase
    {
       SliderService sliderService;
        TawredatDbContext Ctx;
        public SliderApiController(SliderService SliderService, TawredatDbContext Context)
        {
            sliderService = SliderService;
            Ctx = Context;
        }
        // GET: api/<SliderApiController>
        [HttpGet]
        public IEnumerable<TbSlider> Get()
        {
            return sliderService.getAll();
        }

        // GET api/<SliderApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SliderApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SliderApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SliderApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
