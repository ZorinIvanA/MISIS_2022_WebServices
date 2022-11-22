using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISIS_2022_WebServices.Domain;
using MISIS_2022_WebServices.Model;

namespace MISIS_2022_WebServices.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] BookModel model)
        {
            return StatusCode(StatusCodes.Status201Created,
                _booksRepository.Insert(model.ToDomainObject()));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _booksRepository.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public IActionResult Update([FromForm] BookModel model)
        {
            _booksRepository.Update(model.ToDomainObject());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_booksRepository.GetById(id));
        }
    }
}
