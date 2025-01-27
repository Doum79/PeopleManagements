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
    public class InMemoryPersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public InMemoryPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.OrderBy(p => p.LastName)
                                         .ThenBy(p => p.FirstName)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetByCompanyAsync(string companyName)
        {
            return await _context.Persons
           .Where(p => p.Jobs.Any(j => j.CompanyName == companyName))
           .Include(p => p.Jobs)
           .ToListAsync();
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
             return await _context.Persons.FirstAsync(p => p.Id == id);
        }
    }
}
