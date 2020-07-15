using Abp.Runtime.Validation;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using SprintTek.EntityFrameworkCore;
using SprintTek.PhoneBook;
using SprintTek.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SprintTek.Tests.PhoneBook
{
    public class PersonAppService_Tests: AppTestBase
    {
        private readonly IPersonAppService _personAppService;
        private readonly SprintTekDbContext _context;

        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter() 
        {
            var persons = _personAppService.GetPeople(new GetPeopleInput
            {
                Filter = "adams"
            }); 
            
            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("Douglas");
            persons.Items[0].Surname.ShouldBe("Adams");

        }

        [Fact]
        public async Task Should_Create_Person_With_Valid_Arguments() 
        {
            await _personAppService.CreatePerson(new CreatePersonInput
            {
                Name = "Sergjake",
                Surname = "Moreno",
                EmailAddress = "sergjake.moreno@sprintshipworldwide.com"
            });

            UsingDbContext(
                _context => {
                    var person = _context.Persons.FirstOrDefault(p => p.EmailAddress == "sergjake.moreno@sprintshipworldwide.com");
                    person.ShouldNotBe(null);
                    person.Name.ShouldBe("Sergjake");

                }
            );
        }

        [Fact]
        public async Task Should_Not_Create_Person_With_Invalid_Arguments() 
        {

            await Assert.ThrowsAsync<AbpValidationException>(
                async () => { 
                    await _personAppService.CreatePerson(new CreatePersonInput
                    {
                        Name = "Sergjake"
                    });
                });
            
        }

    }
}
