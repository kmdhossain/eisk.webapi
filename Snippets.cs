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
