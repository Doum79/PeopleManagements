using Microsoft.AspNetCore.Mvc;
using PeopleManager.Application.DTOs;
using PeopleManager.Application.Services;
using PeopleManager.Domain.Entities;

namespace PeopleManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly PersonService _personService;

        public PersonsController(PersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] CreatePersonDto personDto)
        {
            try
            {
              await  _personService.AddPersonAsync(personDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _personService.GetAllPersonsAsync();
            return Ok(persons);
        }
    }
}
