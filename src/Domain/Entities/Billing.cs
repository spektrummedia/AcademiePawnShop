using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Billing : EntityBase<Guid>
    {
        [ForeignKey("CustomerId")]
        public virtual Customer Customer{ get; set; }

        public float Total { get; set; }
    }
}
