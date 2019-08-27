using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Domain.Entities
{
    public class Product : EntityBase<Guid>
    {
        public string name { get; set; }

        public int price { get; set; }

        public int quatity { get; set; }
    }
}
