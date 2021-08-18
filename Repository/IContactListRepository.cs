using System.Collections.Generic;
using VSStudioTestPRJ.Models;

namespace VSStudioTestPRJ.Repository
{
    public interface IContactListRepository
    {
        bool CreatePerson(Person person);
        IEnumerable<Person> GetAllPerson();
    }
}