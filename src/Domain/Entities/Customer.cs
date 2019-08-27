using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Customer  : EntityBase<Guid>    {
        public string name { get; set; }

        public string phoneNumber { get; set; }

    }
}
