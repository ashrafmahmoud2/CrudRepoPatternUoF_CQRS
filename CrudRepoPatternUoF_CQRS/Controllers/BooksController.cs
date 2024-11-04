using CrudRepoPatternUoF_CQRS.Core;
using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            await _unitOfWork.Books.AddAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id) return BadRequest();

            _unitOfWork.Books.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null) return NotFound();

            _unitOfWork.Books.Delete(book);
            return NoContent();
        }
  
    }
}
