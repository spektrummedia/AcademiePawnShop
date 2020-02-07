using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Academie.PawnShop.Tests.Application.Services
{
    public class InventoryManagerTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(-5)]
        public async Task InventoryManager_Should_Replenish_Stocks_For_Product(int quantityToOrder)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            var product = new Product()
            {
                Name = "Rasberry PI 2",
                Quantity = 3,
                Price = 10.99
            };
            var expectedQuantity = product.Quantity + quantityToOrder;

            db.Products.Add(product);
            db.SaveChanges();


            // Act
            var manager = new InventoryManager(db);
            await manager.ReplenishInventory(product.Id, quantityToOrder);

            // Assert
            product.Quantity.ShouldBe(expectedQuantity);
        }
        
        [Fact]
        public async Task InventoryManager_Should_Replenish_Stocks_For_Product_Using_Default_Value()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            var product = new Product()
            {
                Name = "Rasberry PI 2",
                Quantity = 3,
                Price = 10.99
            };
            const int DEFAULT_QUANTITY = 10;
            var expectedQuantity = product.Quantity + DEFAULT_QUANTITY;

            db.Products.Add(product);
            db.SaveChanges();


            // Act
            var manager = new InventoryManager(db);
            await manager.ReplenishInventory(product.Id);

            // Assert
            product.Quantity.ShouldBe(expectedQuantity);
        }

        [Fact]
        public async Task InventoryManager_Should_Return_When_Product_Is_Not_Found()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            const int quantityToOrder = 5;
            const int initialQuantity = 2;
            var product = new Product() {Quantity = initialQuantity};
            product.SoftDelete(); // We SoftDelete the product so it's not found #QueryFilter
            db.Products.Add(product);
            await db.SaveChangesAsync();

            // Act
            var manager = new InventoryManager(db);
            await manager.ReplenishInventory(product.Id, quantityToOrder);

            // Assert
            product.Quantity.ShouldBe(initialQuantity);
        }

    }
}
