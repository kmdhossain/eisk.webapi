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
            var inputProduct = Factory_Entity<Product>();
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act
            var returnedProduct = await productDomainService.Add(inputProduct);

            //Assert
            Assert.NotNull(returnedProduct);
            Assert.NotEqual(default(int), returnedProduct.ProductId);
        }

        [Fact]
        public virtual async Task ProductOnlineValidate_InvalidProductPricePassed_ThrowException()
        {
            //Arrange
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            inputProduct.ProductPrice = 51;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act + Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                    productDomainService.Add(inputProduct));

        }
    }
}
