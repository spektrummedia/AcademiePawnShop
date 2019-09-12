using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class JobTitle : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
