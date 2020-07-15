using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SprintTek.PhoneBook.Dto
{
    public class PersonListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }

    public class PhoneInPersonListDto 
    { 
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}
