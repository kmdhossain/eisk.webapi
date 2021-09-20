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

    public class ProductDataService : EntityDataService <Product>, IProductDataService
    {
        public ProductDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IList<Product>> GetByProductName(string productName)
        {
            return await DbContext.Set<Product>().Where(x => x.ProductName.Contains(productName)).ToListAsync();
        }

    }
}