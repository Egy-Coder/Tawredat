using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TawredatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsAndConditionsApiController : ControllerBase
    {
       TermAndConditionService termAndConditionService;
       TawredatDbContext Ctx;
        public TermsAndConditionsApiController(TermAndConditionService TermAndConditionService, TawredatDbContext Context)
        {
            termAndConditionService = TermAndConditionService;
            Ctx = Context;
        }
        // GET: api/<TermsAndConditionsApiController>
        [HttpGet]
        public IEnumerable<TbTermAndCondition> Get()
        {
            return termAndConditionService.getAll();
        }

        // GET api/<TermsAndConditionsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TermsAndConditionsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TermsAndConditionsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TermsAndConditionsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
