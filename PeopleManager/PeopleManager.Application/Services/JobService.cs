using PeopleManager.Application.DTOs;
using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Application.Services
{
    public class JobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task AddJobToPersonAsync(Guid personId, AddJobDto jobs)
        {
            var job = new Job
            {
                CompanyName = jobs.CompanyName,
                Position = jobs.Position,
                StartDate = jobs.StartDate,
                EndDate = jobs.EndDate, 
                PersonId = personId
            };

            await _jobRepository.AddJobAsync(job);
        }
    }
}
