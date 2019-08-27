using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quatity { get; set; }
    }
}
