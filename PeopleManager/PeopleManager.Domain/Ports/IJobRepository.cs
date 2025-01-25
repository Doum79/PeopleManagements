using PeopleManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Domain.Ports
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
        Task<IEnumerable<Job>> GetJobsByPersonBetweenDatesAsync(Guid personId, DateTime startDate, DateTime endDate);
    }
}
