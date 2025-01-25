using PeopleManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Domain.Ports
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(Guid id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task<IEnumerable<Person>> GetByCompanyAsync(string companyName);
        Task AddAsync(Person person);
    }
}
