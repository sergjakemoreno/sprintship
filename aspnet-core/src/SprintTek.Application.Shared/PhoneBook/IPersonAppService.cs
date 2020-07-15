using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SprintTek.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SprintTek.PhoneBook
{
    public interface IPersonAppService: IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(EntityDto input);

        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);

        Task EditPerson(EditPersonInput input);

        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task DeletePhone(EntityDto<long> input);
    }
}
