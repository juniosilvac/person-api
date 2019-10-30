using Core.Person.Business;
using Core.Person.Data.VO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Person.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut()]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null)
            {
                return NoContent();
            }

            return new ObjectResult(_bookBusiness.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);

            return NoContent();
        }
    }
}
