using System;
using System.IO;
using System.Threading.Tasks;
using Eisk.Core.Exceptions;
using Eisk.DataServices.EFCore;
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
    [Fact]// postive test
    public virtual async Task ProductAdd_ProductIsNotOnline_PriceMoreThan50()
        {
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = false;
            const int PRODUCT_PRICE_IS_MORE_THAN = 51;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS_MORE_THAN;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act
            var returnProduct = await productDomainService.Add(inputProduct);

            //Assert

            Assert.NotNull(returnProduct);
            Assert.NotEqual(default(int), returnProduct.ProductId);


        }

        [Fact] //negative test
        public virtual async Task ProductAdd_ProductIsOnline_Prize_Is_Less_Than_Zero()
        {
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRICE_IS_LESS_THAN_ZERO = 0;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS_LESS_THAN_ZERO;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act+Assert
            await Assert.ThrowsAsync<InvalidDataException<Product>>(()=>
            productDomainService.Add(inputProduct)
         );
        }

        //Positive boundary test

        [Fact]

        public virtual async Task ProductAdd_ProductIsOnline_PriceEqual50_ShouldNotThrowException()
        {
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = false;
            const int PRODUCT_PRICE = 50;
            inputProduct.ProductPrice = PRODUCT_PRICE;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act

            var returnProduct = await productDomainService.Add(inputProduct);

            //Assert

            Assert.NotNull(returnProduct);
            Assert.NotEqual(default(int), returnProduct.ProductId);

        }

        //Negative boundary test

        [Fact]

        public virtual async Task ProductAdd_ProductIsOnline_PrizeIsEqualZero_ShouldThrowException()
        {
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRIZE = 0;
            inputProduct.ProductPrice = PRODUCT_PRIZE;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act+Assert
            await Assert.ThrowsAsync<InvalidDataException<Product>>(() =>
            productDomainService.Add(inputProduct)

                );
        }
    }
}


