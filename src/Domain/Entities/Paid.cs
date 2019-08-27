using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Paid : EntityBase<Guid>
    {   
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public float Salary { get; set; }

        public DateTime Date { get; set; }
    }
}
