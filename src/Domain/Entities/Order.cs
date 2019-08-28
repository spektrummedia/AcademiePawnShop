using System;
using System.Collections.Generic;

namespace Academie.PawnShop.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public string Client { get; set; }
        public IEnumerable<OrderEntry> Entries { get; set; } // 1 ==> N
        public float Total { get; set; }
    }
}
