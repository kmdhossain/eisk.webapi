using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace Eisk.DomainServices
{
    using Core.DomainService;
    using DataServices.Interfaces;
    using Domains.Entities;
    using Eisk.Core.Exceptions;

    public class OrderDomainService : DomainService<Order, int>
    {
        private readonly IOrderDataService _orderDataService;
        // private DataServices.EFCore.EmployeeDataService employeeDataService;

        public OrderDomainService(IOrderDataService orderDataService) : base(orderDataService)
        {
            _orderDataService = orderDataService;
        }


        public async Task<Order> GetByOrdertId(int orderId)
        {
            return await _orderDataService.GetByOrderID(orderId);
        }

        public override Task<Order> Add(Order entity)
        {
            return base.Add(entity, ApplyOrderBusinessRule);
        }

        private static void ApplyOrderBusinessRule(Order e)
        {
            e.OrderCalculatedTotal = 0;
            foreach (var orderItem in e.OrderItems)
                e.OrderCalculatedTotal += orderItem.OrderItemProduct.ProductPrice;

            if (e.OrderCalculatedTotal >= 200)
                e.OrderCalculatedTotal = e.OrderCalculatedTotal * 0.8;
        }
    }
}