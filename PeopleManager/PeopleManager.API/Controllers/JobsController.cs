using Microsoft.AspNetCore.Mvc;
using PeopleManager.Application.DTOs;
using PeopleManager.Application.Services;

namespace PeopleManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobService _jobService;

        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost("{personId}/jobs")]
        public async Task<IActionResult> AddJob(Guid personId, [FromBody] AddJobDto jobDto)
        {
           await _jobService.AddJobToPersonAsync(personId, jobDto);
            return Ok();
        }
    }
}
