using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("api/author")]    
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;

        public AuthorController(IRepositoryManager _repository, IMapper _mapper)
        {
            repository =_repository;
            mapper = _mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAuthors()
        {
            var authors = repository.Author.GetAuthors();
            var authorsDto = mapper.Map<IEnumerable<GetAuthorsDto>>(authors);

            return Ok(authorsDto);
        }

        [HttpGet("{id}", Name = "AuthorById")]
        public IActionResult GetAuthorID(int id)
        {
            var author = repository.Author.GetAuthorID(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<GetAuthorsDto>(author);

            return Ok(authorDto);
        }

        [HttpGet("{id}/books")]
        public IActionResult GetBooksAuthor(int id)
        {
            var author = repository.Author.GetAuthorID(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<ShowBooksAuthorDto>(author);

            return Ok(authorDto);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest("AuthorForCreationDto object is null");
            }
            var authorEntity = mapper.Map<Author>(author);
            repository.Author.CreateAuthor(authorEntity);
            repository.Save();
            var authorToReturn = mapper.Map<GetAuthorsDto>(authorEntity);
            return CreatedAtRoute("AuthorById", new { id = authorToReturn.AuthorID }, authorToReturn);
        }

        [HttpPost("authorbook")]
        public IActionResult CreateAuthorBook([FromBody] AuthorBookDto authorbook)
        {
            if (authorbook == null)
            {
                return BadRequest("AuthorBookDto object is null");
            }
            var author = repository.Author.GetAuthorID(authorbook.AuthorID);
            var book = repository.Book.GetBookID(authorbook.BookID);
            if (book == null || author ==null)
            {
                return NotFound();
            }
            book.Authors.Add(author);
            repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = repository.Author.GetAuthorID(id);
            if (author == null)
            {
                return NotFound();
            }
            repository.Author.DeleteAuthor(author);
            repository.Save();
            return NoContent();
        }
    }
}
