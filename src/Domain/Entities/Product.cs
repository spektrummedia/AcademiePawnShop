using System;

namespace Academie.PawnShop.Domain.Entities
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quatity { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
            
        
    }
}
