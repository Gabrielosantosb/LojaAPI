using Loja.Services.HyperMedia.Filters;
using Loja.Services.Services.PersonServices;
using Loja.Services.Services.PersonServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
//using WebApplication4.Services.Implementations;

namespace Loja.API.Controllers
{

    [ApiVersion("1.0")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());

        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Usuário não encontrado");

            return Ok(_personService.FindById(id));

        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));

        }

        [HttpPut("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]     
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]

        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(int id, [FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            if (id != person.Id) return BadRequest("O ID do objeto não corresponde ao ID");
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((200))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound("Usuário não encontrado");
            _personService.Delete(id);
            return Ok($"Usuário de id {id} deletado");
        }


        [HttpDelete("all")]        
        public IActionResult DeleteAll()
        {
            var deletedPersons = _personService.DeleteAll();
            if (deletedPersons.Count == 0)
            {
                return NotFound("Nenhum registro de pessoa para excluir.");
            }

            return Ok("Todos usuários deletados");
        }
    }
}


