using System;
using System.Collections.Generic;
using System.Linq;
using VSStudioTestPRJ.Models;

namespace VSStudioTestPRJ.Repository
{
    public class ContactListRepository : IContactListRepository
    {
        private readonly NoelDBContext _context;
        public ContactListRepository(NoelDBContext noelDBContext)
        {
            _context = noelDBContext;
        }

        public bool CreatePerson(Person person)
        {
            try
            {
                if (_context.Person.Any(x => x.Email == person.Email))
                {
                    return false;
                }

                Person newPerson = new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    MiddleName = person.MiddleName == null ? string.Empty : person.MiddleName,
                    Phone = person.Phone,
                    Email = person.Email,
                    CreatedBy = "Noel Donaldson",
                    ModifiedBy = "Noel Donaldson",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                _context.Person.Add(newPerson);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return _context.Person.OrderBy(x => x.LastName);
        }
    }
}
