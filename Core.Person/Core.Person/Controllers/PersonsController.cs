using Core.Person.Business;
using Microsoft.AspNetCore.Mvc;

namespace Person.Api.Controllers
{   
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Core.Person.Model.Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Core.Person.Model.Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_personBusiness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
