using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TawredatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchApiController : ControllerBase
    {
        ProductService productService;
        TawredatDbContext Ctx;
        public SearchApiController(ProductService ProductService, TawredatDbContext Context)
        {
            productService = ProductService;
            Ctx = Context;
        }
        // GET: api/<SearchApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SearchApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbProduct> Get(string id)
        {
            return productService.getAll().Where(a => a.ProductName.Contains(id)).ToList();
        }

        // POST api/<SearchApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SearchApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SearchApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
