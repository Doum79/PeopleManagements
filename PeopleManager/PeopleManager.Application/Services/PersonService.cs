using PeopleManager.Domain.Entities;
using PeopleManager.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> AddPersonAsync(string firstName, string lastName, DateTime birthDate)
        {
            if ((DateTime.Now - birthDate).TotalDays / 365.25 > 150)
                throw new ArgumentException("La personne ne peut pas avoir plus de 150 ans.");

            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            await _personRepository.AddAsync(person);
            return person;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllAsync();
        }
    }
}
