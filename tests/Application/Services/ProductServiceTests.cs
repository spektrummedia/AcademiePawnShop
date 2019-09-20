using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using Xunit;

namespace Academie.PawnShop.Tests.Application.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void ProductService_Should_Add_Taxe()
        {
            //Arange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            var productQuantity = 10;
            var productPrice = 10;

            //Act
            var productService = new ProductService(db);
            productService.SetPriceWithTaxe(productQuantity, productPrice);

            //Assert
            productService.Total.ShouldBe(114.975);

        }


        [Theory]
        [InlineData(5,2)]
        [InlineData(20,10)]
        [InlineData(3, 0)]
        public void SetDeal(double quantity, double deal)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var db = new PawnShopDbContext(options);

            //Act
            var productService = new ProductService(db);
            productService.SetDeal(quantity);
            //Assert

            productService.Deal.ShouldBe(deal);
        }
    }
}
