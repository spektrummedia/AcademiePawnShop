using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Employee : EntityBase<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NAS { get; set; }

        public float Salary { get; set; }

        public bool FullTime { get; set; }

        public StreetAddress Address { get; set; }

        public string Post { get; set; }
    }
}
