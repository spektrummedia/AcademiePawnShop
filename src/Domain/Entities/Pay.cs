using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Pay : EntityBase<Guid>
    {
        public float TotalPay { get; set; }
        public IEnumerable<EmployeePay> Employees { get; set; }
    }
}
