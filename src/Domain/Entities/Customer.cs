using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Customer  : EntityBase<Guid>    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

    }
}
