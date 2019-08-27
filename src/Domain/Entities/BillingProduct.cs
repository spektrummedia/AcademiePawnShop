using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class BillingProduct : EntityBase<Guid>
    {
        [ForeignKey("BillingId")]
        public virtual Billing Billing { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product{ get; set; }

        public int Quantity { get; set; }
    }
}
