using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Application.Services
{
    public class ProductService : IProductServices
    {
        private const double tps = 5;
        private const double tvq = 9.25;

        public int Quatity { get; set; }
        public double Total { get; set; }

        public double Deal { get; set; }

        public void SetPriceWithTaxe(double quantity, double productPrice)
        {
            
            var taxe = (productPrice * quantity) * (tps / 100);
            Total = (productPrice * quantity) + 5;
        }

        public void SetDeal(double quantity)
        {
            switch (quantity)
            {
                case 5:
                    Deal = 2;
                    break;
                case 10:
                    Deal = 5;
                    break;
                case 20:
                    Deal = 10;
                    break;
                default:
                    Deal = 0;
                    break;
            }
        }
    }
}
