using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;
using Xunit;

namespace Eisk.DomainServices.ComponentTests.EFCore
{
    public class OrderDomainServiceCustomComponentTests:TestBase
    {
        static OrderDataService Factory_DataService()
        {
            OrderDataService orderDataService = new OrderDataService(TestDbContextFactory.CreateDbContext());

            return orderDataService;
        }


        [Fact]
        public virtual async Task Add_OrderWithNoDiscountPassed_ShouldCaculateValueCorrectly()
        {
            // Arrange
            var order = new Order();
            order.OrderItems = new List<OrderItem>();

            var product1 = new Product
            {
                ProductId = 1,
                IsOnline = true,
                ProductCost = 20,
                ProductName = "Mango Juice"
            };
            var orderItem1 = new OrderItem
            {
                OrderItemId = 100,
                OrderItemProduct = product1
            };

            order.OrderItems.Add(orderItem1);

            OrderDomainService orderDomainService = new OrderDomainService(Factory_DataService());

            var expectedOrderTotal = 20;

            //Act
            var actualOrder = await orderDomainService.Add(order);

            //Assert
            Assert.Equal(expectedOrderTotal, actualOrder.OrderCalculatedTotal);
        }

    }
}
