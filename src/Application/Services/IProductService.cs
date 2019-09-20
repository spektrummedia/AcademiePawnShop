using Academie.PawnShop.Domain.Entities;
using System;

namespace Academie.PawnShop.Application.Services
{
    public interface IProductService
    {
        double Total { get; }
        int Quatity { get; }

        Product GetProductById(Guid id);
        void SetPriceWithTaxe(double quantity, double productPrice);
        void SetDeal(double quantity);
    }
}
