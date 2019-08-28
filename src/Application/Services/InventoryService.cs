using Academie.PawnShop.Domain;
using Spk.Common.Helpers.Guard;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Academie.PawnShop.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly PawnShopDbContext _db;

        public InventoryService(PawnShopDbContext db)
        {
            _db = db.GuardIsNotNull(nameof(db));
        }

        public bool IsProductInStock(Guid productId)
        {
            return _db.Products.First(x => x.Id == productId).Quantity > 0;
        }

        public async Task ReplenishInventory(Guid productId, int quantityToOrder = 10)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == productId);

            if (product == null)
                return;

            product.Quantity += quantityToOrder;

            await _db.SaveChangesAsync();
        }
    }
}
