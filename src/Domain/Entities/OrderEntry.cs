using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academie.PawnShop.Domain.Entities
{
    public class OrderEntry : EntityBase<Guid>
    {
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product{ get; set; }
        public int Quantity { get; set; }
    }
}
