using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class EmployeePay : EntityBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        public Guid PayId { get; set; }
        [ForeignKey(nameof(PayId))]
        public virtual Pay Pay { get; set; }
    }
}
