using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddPerson([FromBody] Person request)
        {
            try
            {
                var person = await _personService.AddPersonAsync(request.FirstName!, request.LastName!, request.BirthDate);
                return CreatedAtAction(nameof(_personService.GetAllPersonsAsync), new { id = person.Id }, person);
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
