using System;
using System.Collections.Generic;
using System.Text;

namespace Academie.PawnShop.Application.Services
{
    public interface IProductServices
    {
        double Total { get; }
        int Quatity { get; }

        void SetPriceWithTaxe(double quantity, double productPrice);
        void SetDeal(double quantity);
    }
}
