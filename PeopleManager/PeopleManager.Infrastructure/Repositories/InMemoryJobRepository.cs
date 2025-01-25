using Microsoft.EntityFrameworkCore;
using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Ports;
using PeopleManager.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Infrastructure.Repositories
{
    public class InMemoryJobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public InMemoryJobRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task AddJobAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

       public async Task<IEnumerable<Job>> GetJobsByPersonBetweenDatesAsync(Guid personId, DateTime startDate, DateTime endDate)
        {
            return await _context.Jobs
           .Where(j => j.PersonId == personId && j.StartDate >= startDate && (j.EndDate == null || j.EndDate <= endDate))
           .ToListAsync();
        }
    }
}
