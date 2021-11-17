using System.Collections.Generic;
using Eisk.Core.DataService;
using System.Threading.Tasks;
using Eisk.Domains.Entities;

namespace Eisk.DataServices.Interfaces
{
    public interface IOrderDataService: IEntityDataService<Order>
    {
        Task<Order> GetByOrderID(int orderId);
        Task<IList<Product>> GetByProductId(int productId);
       // Task<IList<Order>> GetByProductName(string productName);

    }
}