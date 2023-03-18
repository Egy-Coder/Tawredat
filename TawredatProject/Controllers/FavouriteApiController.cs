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
    public class FavouriteApiController : ControllerBase
    {
        FavouriteService favouriteService;
        TawredatDbContext Ctx;
        public FavouriteApiController(FavouriteService FavouriteService, TawredatDbContext Context)
        {
            favouriteService = FavouriteService;
            Ctx = Context;
        }
        // GET: api/<FavouriteApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FavouriteApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbFavourite> Get(string id)
        {
            return favouriteService.getAll().Where(A => A.Id == id).ToList();
        }

        // POST api/<FavouriteApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FavouriteApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavouriteApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
