using Academie.PawnShop.Application.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Academie.PawnShop.Tests.Application.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void ProductService_Should_Add_Taxe()
        {
            //Arange
            var productQuantity = 10;
            var productPrice = 10;

            //Act
            var productService = new ProductService();
            productService.SetPriceWithTaxe(productQuantity, productPrice);

            //Assert
            productService.Total.ShouldBe(105);

        }


        [Theory]
        [InlineData(5,2)]
        [InlineData(20,10)]
        [InlineData(3, 0)]
        public void SetDeal(double quantity, double deal)
        {
            //Arrange

            //Act
            var productService = new ProductService();
            productService.SetDeal(quantity);
            //Assert

            productService.Deal.ShouldBe(deal);
        }
    }
}
