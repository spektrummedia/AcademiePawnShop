using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Employee : EntityBase<Guid>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public float Salary { get; set; }

        [ForeignKey("JobTitleId")]
        public JobTitle JobTitle { get; set; }


        public IEnumerable<EmployeePay> Pay { get; set; }
    }
}
