using Microsoft.AspNetCore.Mvc;
using Rwe.App.Abstractions;
using Rwe.App.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rwe.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWindparkClient windparkClient;
        private readonly IMessageProducer messageProducer;

        public TestController(IWindparkClient windparkClient, IMessageProducer messageProducer)
        {
            this.windparkClient = windparkClient;
            this.messageProducer = messageProducer;
        }

        // GET: api/<TestController>
        [HttpGet]
        public async Task<IEnumerable<Park>> GetAsync()
        {
            var data = await windparkClient.GetParks();

            messageProducer.SendMessage(data);

            return data;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<TestController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TestController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}