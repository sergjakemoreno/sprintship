using SprintTek.EntityFrameworkCore;
using SprintTek.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SprintTek.Migrations.Seed.Host
{
    public class InitialPeopleAndPhoneCreator
    {
        private readonly SprintTekDbContext _context;

        public InitialPeopleAndPhoneCreator(SprintTekDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com",
                        Phones = new List<Phone> { 
                            new Phone {Type = PhoneType.Home, Number = "12345678" },
                            new Phone {Type = PhoneType.Mobile, Number = "09560121192" },
                        }
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org",
                        Phones = new List<Phone> {
                            new Phone {Type = PhoneType.Home, Number = "65498712" },
                        }
                    });
            }
        }
    }
}
