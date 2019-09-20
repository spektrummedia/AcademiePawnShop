using Academie.PawnShop.Domain;
using Spk.Common.Helpers.Guard;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Academie.PawnShop.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductService _productService;
        private readonly PawnShopDbContext _db;

        public InventoryService(IProductService productService, PawnShopDbContext db)
        {
            _productService = productService.GuardIsNotNull(nameof(productService));
            _db = db.GuardIsNotNull(nameof(db));
        }

        public bool IsProductInStock(Guid productId)
        {
            return _db.Products.First(x => x.Id == productId).Quantity > 0;
        }

        public async Task ReplenishInventory(Guid productId, int quantityToOrder = 10)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
                return;

            product.Quantity += quantityToOrder;

            await _db.SaveChangesAsync();
        }
    }
}
