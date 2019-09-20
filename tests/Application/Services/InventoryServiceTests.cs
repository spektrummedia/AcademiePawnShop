using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Academie.PawnShop.Tests.Application.Services
{
    public class InventoryServiceTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(-5)]
        public void InventoryService_Should_Replenish_Stocks_For_Product(int quantityToOrder)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            var productServiceMock = new Mock<IProductService>();
            
            var product = new Product()
            {
                Name = "Rasberry PI 2",
                Quantity = 3,
                Price = 10.99
            };
            productServiceMock.Setup(x => x.GetProductById(It.IsAny<Guid>())).Returns(product);

            var expectedQuantity = product.Quantity + quantityToOrder;

            db.Products.Add(product);
            db.SaveChanges();


            // Act
            var service = new InventoryService(productServiceMock.Object, db);
            var result = service.ReplenishInventory(product.Id, quantityToOrder);

            // Assert
            product.Quantity.ShouldBe(expectedQuantity);
        }
        
        [Fact]
        public void InventoryService_Should_Replenish_Stocks_For_Product_Using_Default_Value()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(x => x.GetProductById(It.IsAny<Guid>()));

            var product = new Product()
            {
                Name = "Rasberry PI 2",
                Quantity = 3,
                Price = 10.99
            };
            productServiceMock.Setup(x => x.GetProductById(It.IsAny<Guid>())).Returns(product);

            const int DEFAULT_QUANTITY = 10;
            var expectedQuantity = product.Quantity + DEFAULT_QUANTITY;

            db.Products.Add(product);
            db.SaveChanges();


            // Act
            var service = new InventoryService(productServiceMock.Object, db);
            var result = service.ReplenishInventory(product.Id);

            // Assert
            productServiceMock.Verify(x => x.GetProductById(It.Is<Guid>(id => id == product.Id)), Times.Once);
            product.Quantity.ShouldBe(expectedQuantity);
        }

    }
}
