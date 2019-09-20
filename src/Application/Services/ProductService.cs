using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using System;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Academie.PawnShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PawnShopDbContext _db;
        private const double tps = 5;
        private const double tvq = 9.975;

        public int Quatity { get; set; }
        public double Total { get; set; }

        public double Deal { get; set; }


        public ProductService(PawnShopDbContext db)
        {
            _db = db.GuardIsNotNull(nameof(db));
        }

        public Product GetProductById(Guid id)
        {
            return _db.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SetPriceWithTaxe(double quantity, double productPrice)
        {
            
            var tax = (productPrice * quantity) * ((tps + tvq )/ 100);
            Total = (productPrice * quantity) + tax;
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
