using System;
using System.Threading.Tasks;

namespace Academie.PawnShop.Application.Services
{
    public interface IInventoryService
    {
        bool IsProductInStock(Guid id);
        Task ReplenishInventory(Guid id, int quantityToOrder = 10);
    }
}
