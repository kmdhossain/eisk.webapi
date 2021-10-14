using System;
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
            await Assert.ThrowsAsync<InvalidDataException<Product>>(() =>
            productDomainService.Add(inputProduct)
            );

        }


        // <summary>
        // Positive test: Test case for product is not online, price is less than 50.
        // </summary>
        [Fact]
        public virtual async Task ProductAdd_IsNotOnline_AndPriceIsLessThan50()
        {
            //Arrange

            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = false;
            const int PRODUCT_PRICE_IS_LESS_THAN = 49;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS_LESS_THAN;
            var prodductDomainService = new ProductDomainService(Factory_DataService());

            ///Act
            var returnProduct = await prodductDomainService.Add(inputProduct);
            //Assert
            Assert.NotNull(returnProduct);
            Assert.NotEqual(default(int), returnProduct.ProductId);
        }

        //<summary>
        //Positive test: Test case for product is not online and price is more than 50
        //</summary>
        [Fact]
        public virtual async Task ProductAdd_IsNotOnline_AndPriceIsMoreThan50()
        {
            //Arrange
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

        //<summary>
        //Positive test: product is not online and price is equal to 50, should not throw exception
        //</summary>

        [Fact]
        public virtual async Task ProductAdd_ProductIsNotOnline_PriceIsEqual50()
        {

            //Arrange
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = false;
            const int PRODUCT_PRICE_IS = 50;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS;
            var productDomainService = new ProductDomainService(Factory_DataService());


            //Act
            var returnProduct = await productDomainService.Add(inputProduct);
            //Assert
            Assert.NotNull(returnProduct);
            Assert.NotEqual(default(int), returnProduct.ProductId);

        }
        //<summary>
        //Negative test (boundary):  product is online and price is more than 50 (int.max) (negative tests)
        //</summary>
        [Fact]

        public virtual async Task ProductAdd_IsOnline_PriceIsMoreThan_50()
        {
            var inputProduct = Factory_Entity<Product>();
            inputProduct.IsOnline = true;
            const int PRODUCT_PRICE_IS_MORE_THAN = 51;
            inputProduct.ProductPrice = PRODUCT_PRICE_IS_MORE_THAN;
            var productDomainService = new ProductDomainService(Factory_DataService());

            //Act +Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            productDomainService.Add(inputProduct)
            );


        }

    }
}


