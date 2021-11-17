using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eisk.Core.DataService.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Eisk.DataServices.EFCore
{
    using DataContext;
    using Interfaces;
    using Domains.Entities;

    public class OrderDataService : EntityDataService <Order>, IOrderDataService
    {
        public OrderDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Order> GetByOrderID(int orderId)
        {
            return await DbContext.Set<Order>().FindAsync(orderId);
        }

        public Task<IList<Product>> GetByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}