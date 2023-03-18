using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TawredatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingCartApiController : ControllerBase
    {
        PurchasingCartService purchasingCartService;
        TawredatDbContext Ctx;
        public PurchasingCartApiController(PurchasingCartService PurchasingCartService, TawredatDbContext Context)
        {
            purchasingCartService = PurchasingCartService;
            Ctx = Context;
        }
        // GET: api/<PurchasingCartApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PurchasingCartApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbPurchasingCart> Get(string id)
        {
            return purchasingCartService.getAll().Where(A => A.Id == id).ToList();
        }

        // POST api/<PurchasingCartApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PurchasingCartApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchasingCartApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
