using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;

        public BookController(IRepositoryManager _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet("{id}", Name = "BookById")]
        public IActionResult GetBookID(int id)
        {
            var book = repository.Book.GetBookID(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = mapper.Map<GetBookDto>(book);

            return Ok(bookDto);
        }


        [HttpPost]
        public IActionResult CreateBook([FromBody] BookForCreationDto book)
        {
            if (book == null)
            {
                return BadRequest("BookForCreationDto object is null");
            }
            if(book.Name.Length>30)
            {
                return BadRequest("Length > 30");
            }
            var bookEntity = mapper.Map<Book>(book);
            var authors = repository.Author.GetAuthors();
            var author = authors.FirstOrDefault(id => id.AuthorID==book.AuthorID);
            bookEntity.Authors.Add(author);
            repository.Book.CreateBook(bookEntity);
            repository.Save();
            var bookToReturn = mapper.Map<GetBookDto>(bookEntity);

            return CreatedAtRoute("BookById", new { id = bookToReturn }, bookToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = repository.Book.GetBookID(id);
            if (book == null)
            {
                return NotFound();
            }
            repository.Book.DeleteBook(book);
            repository.Save();
            return NoContent();
        }
    }
}
