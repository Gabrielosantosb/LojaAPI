using Loja.Services.Services.BooksServices;
using Loja.Services.Services.BooksServices.Models;
using Loja.Services.Services.PersonServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Loja.API.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [ProducesResponseType((200), Type = typeof(List<BooksVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get()
        {
            return Ok(_booksService.FindAll());

        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BooksVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult GetById(long id)
        {
            var books = _booksService.FindById(id);
            if (books == null) return NotFound("Livro não encontrado");

            return Ok(_booksService.FindById(id));
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] BooksVO books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksService.Create(books));

        }

        [HttpPut("{id}")]
        [ProducesResponseType((200))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Put(int id, [FromBody] BooksVO books)
        {
            if (books == null) return BadRequest();
            if (id != books.Id) return BadRequest("O ID do objeto não corresponde ao ID");
            return Ok(_booksService.Update(books));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((200))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
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


