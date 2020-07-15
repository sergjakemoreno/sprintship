﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SprintTek.Sessions.Dto;

namespace SprintTek.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}