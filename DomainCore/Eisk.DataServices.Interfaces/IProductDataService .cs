using System.Collections.Generic;
using Eisk.Core.DataService;
using System.Threading.Tasks;
using Eisk.Domains.Entities;

namespace Eisk.DataServices.Interfaces
{
    public interface IProductDataService: IEntityDataService<Product>
    {
        //Task<IList<Product>> GetByProductId(int productId);
        Task<IList<Product>> GetByProductName(string productName);

    }
}