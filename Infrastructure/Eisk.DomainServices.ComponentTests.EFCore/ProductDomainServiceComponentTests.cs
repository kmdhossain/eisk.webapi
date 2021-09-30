using System;
using System.Threading.Tasks;
using Eisk.Core.Exceptions;
using Eisk.DataServices.EFCore;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Entities;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;
using Xunit;

namespace Eisk.DomainServices.ComponentTests.EFCore
{
    public class ProductDomainServiceComponentTests : TestBase
    {
        static ProductDataService Factory_DataService()
        {
            ProductDataService productDataService = new ProductDataService(TestDbContextFactory.CreateDbContext());

            return productDataService;
        }

        [Fact]
        public virtual async Task Add_ValidProductID_ShouldReturnProductAfterCreation()
        {
            //Arrange
            var inputProduct = Factory_Entity<Product>(
                x =>
                {
                    x.ProductPrice = 40;
                    x.IsOnline = false;
                }
                );
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act
            var returnedProduct = await productDomainService.Add(inputProduct);

            //Assert
            Assert.NotNull(returnedProduct);
            Assert.NotEqual(default(int), returnedProduct.ProductId);
        }

        [Fact]
        public virtual async Task Add_OnlinePoductWithInvalidLimitPricePassed_ThrowException()
        {
            //Arrange
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRICE_WITH_MORE_THAN_ONLINE_LIMIT = 51;
            inputProduct.ProductPrice = PRODUCT_PRICE_WITH_MORE_THAN_ONLINE_LIMIT;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act + Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                    productDomainService.Add(inputProduct));

        }

        [Fact]
        public virtual async Task Add_ProductNotOnlineAndPriceZero_ShouldThrowException()
        {
            //Arrange
            var inputProduct = Factory_Entity<Product>();

            inputProduct.IsOnline = false;
            const int INVALID_PRODUCT_PRICE_AS_ZERO = 0; 
            inputProduct.ProductPrice = INVALID_PRODUCT_PRICE_AS_ZERO;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act+Assert
            await Assert.ThrowsAsync<DomainException<Product>>(() =>
                    productDomainService.Add(inputProduct));


        }

    }
}
