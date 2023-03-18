using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TawredatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighestSalesApiController : ControllerBase
    {
        SalesInvoiceProductService _salesInvoiceProductService;
        TawredatDbContext Ctx;
        public HighestSalesApiController(SalesInvoiceProductService salesInvoiceProductService, TawredatDbContext Context)
        {
            _salesInvoiceProductService = salesInvoiceProductService;
            Ctx = Context;
        }
        // GET: api/<HighestSalesApiController>
        [HttpGet]
        public IEnumerable<TbSalesInvoiceProduct> Get()
        {
            List<TbSalesInvoiceProduct> products = _salesInvoiceProductService.getAll();
            foreach(var product in products) 
            {

            }
            return _salesInvoiceProductService.getAll();
        }

        // GET api/<HighestSalesApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HighestSalesApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HighestSalesApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HighestSalesApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
