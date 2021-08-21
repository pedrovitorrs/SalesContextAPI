using Microsoft.AspNetCore.Mvc;
using SalesContextAPI.Core.Interfaces.Services.Domain;
using SalesContextAPI.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesContextAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: api/<SellerController>
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            return await _sellerService.GetAllAsync();
        }

        // GET api/<SellerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SellerController>
        [HttpPost]
        public async Task Post([FromBody][Bind("Id,Name")] Seller seller)
        {
            await _sellerService.AddAsync(seller);
        }

        // PUT api/<SellerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SellerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
