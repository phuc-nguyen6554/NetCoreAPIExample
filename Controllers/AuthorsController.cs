using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExampleAPI.Models;
using ExampleAPI.Repository.Authors;
using ExampleAPI.Contracts;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly NetCoreContext _context;
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(NetCoreContext context, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Getauthors()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(long id)
        {
            var author = await _authorRepository.Get(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(long id, Author author)
        {
            if (id != author.ID)
            {
                return BadRequest();
            }

            try
            {
                _authorRepository.Update(author);
                await _authorRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _authorRepository.Create(author);
            await _authorRepository.SaveAsync();

            return CreatedAtAction("GetAuthor", new { id = author.ID }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(long id)
        {
            var author = await _authorRepository.Get(id);

            if(author == null)
            {
                return NotFound();
            }

            _authorRepository.Delete(author);
            await _authorRepository.SaveAsync();

            return author;
        }

        private bool AuthorExists(long id)
        {
            return _context.authors.Any(e => e.ID == id);
        }
    }
}
