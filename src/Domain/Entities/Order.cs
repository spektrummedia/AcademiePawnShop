using System;
using System.Collections.Generic;

namespace Academie.PawnShop.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public string Client { get; set; }
        public IEnumerable<OrderEntry> Entries { get; set; }
        public float Total { get; set; }
    }
}
