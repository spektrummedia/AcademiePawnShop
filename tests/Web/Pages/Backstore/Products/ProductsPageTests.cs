using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Academie.PawnShop.Web.Pages.Backstore.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Academie.PawnShop.Tests.Web.Pages.Backstore.Products
{
    public class ProductsPageTests
    {
        [Fact]
        public void Ctor_Should_Throw_When_DbContext_Is_Null()
        {
            // Arrange
            var inventoryManagerMock = new Mock<IInventoryManager>();

            // Act
            var exception = Record.Exception(() => new IndexModel(null, inventoryManagerMock.Object));

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void Ctor_Should_Throw_When_InventoryService_Is_Null()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            // Act
            var exception = Record.Exception(() => new IndexModel(db, null));

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task OnGet_Should_Return_All_Active_Products()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);
            var inventoryManagerMock = new Mock<IInventoryManager>();
            
            db.Products.Add(new Product());
            var productDeleted = new Product();
            productDeleted.SoftDelete();
            db.Products.Add(productDeleted); 
            await db.SaveChangesAsync();

            // Act
            var page = new IndexModel(db, inventoryManagerMock.Object);
            await page.OnGetAsync();

            // Results
            page.Products.ShouldNotBeEmpty();
            // Take a look at the PawnshopDbContext queryFilter
            page.Products.Count.ShouldBe(1);
        }

        [Fact]
        public async Task OnPostReorder_Should_Call_InventoryManager_With_Product_Id()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);
            var inventoryManagerMock = new Mock<IInventoryManager>();
            inventoryManagerMock.Setup(x => x.ReplenishInventory(It.IsAny<Guid>(), It.IsAny<int>())).Returns(Task.CompletedTask);

            var initialQuantity = 0;
            var product = new Product() {Quantity = initialQuantity };
            db.Products.Add(product);
            await db.SaveChangesAsync();

            // Act
            var page = new IndexModel(db, inventoryManagerMock.Object);
            await page.OnPostReorderAsync(product.Id);

            // Assert
            inventoryManagerMock.Verify(x => x.ReplenishInventory(It.Is<Guid>(id => id == product.Id), It.IsAny<int>()), Times.Once);

            // 👇 Why can't we assert the quantity of the product from here 👇 
            //product.Quantity.ShouldBe(initialQuantity + 10);
        }
    }
}
