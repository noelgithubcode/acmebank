using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoelBankAppPRJ.Repository;
using VSStudioTestPRJ.Models;
using VSStudioTestPRJ.Repository;

namespace VSStudioTestPRJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactListRepository _iContactListRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IMockRepository _iMockRepository;
        public HomeController(
                              IContactListRepository iContactListRepository,
                              IMockRepository iMockRepository,
                              ILogger<HomeController> logger)
        {
            _iContactListRepository = iContactListRepository;
            _iMockRepository = iMockRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mockBankandUser = _iMockRepository.GetMockBankandUser(1, 1);
            return View(mockBankandUser);
        }


        public IActionResult Contact()
        {

            return View(CreatePerson());
        }


        private IEnumerable<Person> CreatePerson()
        {
            foreach (var mock in GetMockPersons())
            {
                _iContactListRepository.CreatePerson(mock);
            }

            return _iContactListRepository.GetAllPerson();
        }

        private List<Person> GetMockPersons()
        {
            List<Person> mocks = new List<Person>(20);
            Person a = new Person
            {
                FirstName = "Sarah",
                LastName = "Parker",
                MiddleName = "Tammy",
                Email = "Sarah.Parker@someemail.com",
                Phone = "(131)131-1313"
            };
            mocks.Add(a);
            ; Person b = new Person
            {
                FirstName = "Meagan",
                LastName = "White",
                MiddleName = "Lara",
                Email = "Meagan.White@someemail.com",
                Phone = "(141)141-1414"
            };
            mocks.Add(b);
            Person c = new Person
            {
                FirstName = "Laura",
                LastName = "Croft",
                MiddleName = "",
                Email = "Laura.Croft@someemail.com",
                Phone = "(151)151-1515"
            };
            mocks.Add(c);
            Person d = new Person
            {
                FirstName = "Angela",
                LastName = "Simmons",
                MiddleName = "Tori",
                Email = "Angela.Simmons@someemail.com",
                Phone = "(161)161-1616"
            };
            mocks.Add(d);
            Person e = new Person
            {
                FirstName = "Anne",
                LastName = "Taylor",
                MiddleName = "Mary",
                Email = "Anne.Taylor@someemail.com",
                Phone = "(171)171-1717"
            };
            mocks.Add(e);
            Person f = new Person
            {
                FirstName = "Julie",
                LastName = "Jacobs",
                MiddleName = "",
                Email = "Julie.Jacobs@someemail.com",
                Phone = "(181)181-1818"
            };
            mocks.Add(f);
            Person g = new Person
            {
                FirstName = "Amanda",
                LastName = "Johnson",
                MiddleName = "Lee",
                Email = "Amanda.Johnson@someemail.com",
                Phone = "(191)191-1919"
            };
            mocks.Add(g);
            Person h = new Person
            {
                FirstName = "Linda",
                LastName = "Carter",
                MiddleName = "Lee",
                Email = "Linda.Carter@someemail.com",
                Phone = "(222)333-4444"
            };
            mocks.Add(h);
            Person i = new Person
            {
                FirstName = "Sally",
                LastName = "Brown",
                MiddleName = "Mae",
                Email = "Sally.Brown@someemail.com",
                Phone = "(101)010-1010"
            };
            mocks.Add(i);
            Person j = new Person
            {
                FirstName = "Sheryl",
                LastName = "Jackson",
                MiddleName = "Monique",
                Email = "Sheryl.Jackson@someemail.com",
                Phone = "(333)444-4444"
            };
            mocks.Add(j);
            return mocks;
        }

        public IActionResult AboutMe()
        {
            return View();
        }

    }
}
