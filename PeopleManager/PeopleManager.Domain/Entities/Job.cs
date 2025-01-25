using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
