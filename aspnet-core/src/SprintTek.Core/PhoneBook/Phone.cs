using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SprintTek.PhoneBook
{
    [Table("tbl_phones")]
    public class Phone: CreationAuditedEntity<long>
    {
        [ForeignKey("PersonId")]
        public virtual Person person { get; set; }
        public virtual int PersonId { get; set; }
        [Required]
        public virtual PhoneType Type{ get; set; }
        [Required]
        public virtual string Number { get; set; }
    }
}
