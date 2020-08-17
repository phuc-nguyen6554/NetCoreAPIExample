using AutoMapper;
using ExampleAPI.Models.Books;
using ExampleAPI.Repository.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class BooksController : ControllerBase
    {
        //private readonly NetCoreContext _context;
        private IBookRepository _repository;
        private IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            //_context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Getbooks()
        {
            var books = await _repository.GetAll();
            var books_dto = _mapper.Map<IEnumerable<BookDTO>>(books);
            return books_dto.ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(long id)
        {
            var book = await _repository.Get(id);
            var bookDto = _mapper.Map<BookDTO>(book);

            if (book == null)
            {
                return NotFound();
            }

            return bookDto;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.ID)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(book);
                await _repository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(CreateBookDTO modelBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(modelBook);

            _repository.Create(book);
            await _repository.SaveAsync();

            var bookDTO = _mapper.Map<BookDTO>(book);

            return CreatedAtAction("GetBook", new { id = book.ID }, bookDTO);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(long id)
        {
            var book = await _repository.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            _repository.Delete(book);
            await _repository.SaveAsync();

            return book;
        }

        private bool BookExists(long id)
        {
            var book = _repository.Get(id);
            return book != null;
        }
    }
}
