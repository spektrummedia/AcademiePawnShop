using System;
using System.Collections.Generic;

namespace Academie.PawnShop.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public IEnumerable<ProductCategory> Products { get; set; } // N ==> N
    }
}
