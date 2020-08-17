using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExampleAPI.Models.Authors;
using ExampleAPI.Repository.Authors;
using ExampleAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AuthorsController : ControllerBase
    {
        private readonly NetCoreContext _context;
        private readonly IAuthorRepository _authorRepository;
        private IMapper _mapper;

        public AuthorsController(NetCoreContext context, IAuthorRepository authorRepository, IMapper mapper)
        {
            _context = context;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        // GET: api/Authors
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Getauthors()
        {
            var author = await _authorRepository.GetAll();
            var authorResult = _mapper.Map<IEnumerable<AuthorDTO>>(author);
            return Ok(authorResult);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(long id)
        {
            var author = await _authorRepository.Get(id);

            if (author == null)
            {
                return NotFound();
            }

            return _mapper.Map<AuthorDTO>(author);
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
        public async Task<ActionResult<CreateAuthorDTO>> PostAuthor([FromBody]CreateAuthorDTO createAuthor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }
            var author = _mapper.Map<Author>(createAuthor);
            _authorRepository.Create(author);
            await _authorRepository.SaveAsync();

            return CreatedAtAction("GetAuthor", new { id = author.ID }, createAuthor);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDTO>> DeleteAuthor(long id)
        {
            var author = await _authorRepository.Get(id);

            if(author == null)
            {
                return NotFound();
            }

            _authorRepository.Delete(author);
            await _authorRepository.SaveAsync();

            var authorDto = _mapper.Map<AuthorDTO>(author);

            return authorDto;
        }

        private bool AuthorExists(long id)
        {
            return _context.authors.Any(e => e.ID == id);
        }
    }
}
