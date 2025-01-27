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
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> AddPersonAsync(CreatePersonDto personDto)
        {
            if (personDto.BirthDate > DateTime.Now.AddYears(-150))
            {
                var person = new Person
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    BirthDate = personDto.BirthDate
                };

                await _personRepository.AddAsync(person);

                return person;
            }
            else
            {
                throw new ArgumentException("La personne ne peut pas avoir plus de 150 ans.");
            }
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllAsync();
        }

      
    }
}
