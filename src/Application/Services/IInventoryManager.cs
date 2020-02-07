using System;
using System.Threading.Tasks;

namespace Academie.PawnShop.Application.Services
{
    public interface IInventoryManager
    {
        bool IsProductInStock(Guid id);
        Task ReplenishInventory(Guid id, int quantityToOrder = 10);
    }
}
