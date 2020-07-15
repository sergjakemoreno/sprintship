using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SprintTek.PhoneBook.Dto
{
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(PersonConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(PersonConsts.MaxSurnameLength)]
        public string Surname { get; set; }
        [MaxLength(PersonConsts.MaxEmailAddressLength)]
        [Required]
        public string EmailAddress { get; set; }
    }
}
