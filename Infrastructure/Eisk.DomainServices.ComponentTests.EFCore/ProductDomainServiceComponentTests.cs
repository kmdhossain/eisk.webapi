using System;
using System.IO;
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
        public virtual async Task ProductAdd_IsOnlineAnd_WhenProductValueIsMoreThan50_ShouldThrowException()
        {

            //Arrange
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRICE_MORE_THAN = 51;
            inputProduct.ProductPrice = PRODUCT_PRICE_MORE_THAN;

            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act + Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
              productDomainService.Add(inputProduct)
                );
        }
        [Fact]

        public virtual async Task ProductAdd_IsOnlineAndProductValueIsZero_ShouldThrowException()
        {
            //Arrange
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRICE_IS_LESS_THAN_ZERO = 0;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS_LESS_THAN_ZERO;
            var productDomainService = new ProductDomainService(Factory_DataService());
            //Act +Assert
            await Assert.ThrowsAsync<DomainException<Product>>(() =>
            productDomainService.Add(inputProduct)
            );

        }
    }
}
