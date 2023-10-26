using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Business;
using WebApplication4.Model;
//using WebApplication4.Services.Implementations;

namespace WebApplication4.Controllers
{

    [ApiVersion("1.0")]
    [ApiController]
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
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());

        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Usuário não encontrado");

            return Ok(_personService.FindById(id));

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person == null) return BadRequest();
            if (id != person.Id) return BadRequest("O ID do objeto não corresponde ao ID");
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
         

            var person = _personService.FindById(id);
            if (person == null) return NotFound("Usuário não encontrado");
            return Ok(_personService.Delete(id));


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


