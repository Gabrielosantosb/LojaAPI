using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Services.BooksServices;
using WebApplication4.Services.BooksServices.Models;

namespace WebApplication4.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {


        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _booksService;

        public BooksController(ILogger<BooksController> logger, IBookService booksService)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksService.FindAll());

        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var books = _booksService.FindById(id);
            if (books == null) return NotFound("Livro não encontrado");

            return Ok(_booksService.FindById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BooksVO books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksService.Create(books));

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BooksVO books)
        {
            if (books == null) return BadRequest();
            if (id != books.Id) return BadRequest("O ID do objeto não corresponde ao ID");
            return Ok(_booksService.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var books = _booksService.FindById(id);
            if (books == null) return NotFound("Usuário não encontrado");
            _booksService.Delete(id);
            return Ok($"Livro de id {id} deletado");
        }

        [HttpDelete("all")]
        public IActionResult DeleteAll()
        {
            var deletedBook = _booksService.DeleteAll();
            if (deletedBook.Count == 0)
            {
                return NotFound("Nenhum registro de pessoa para excluir.");
            }

            return Ok("Todos livros deletados");
        }
    }
}


