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

    public class ProductDomainService : DomainService<Product, int>
    {
        private readonly IProductDataService _productDataService;
        
        public ProductDomainService(IProductDataService productDataService) : base(productDataService)
        {
            _productDataService = productDataService;
        }

        public virtual async Task<IList<Product>> GetByProductName(string productName)
        {
            return await _productDataService.GetByProductName(productName);
        }

        public override Task<Product> Add(Product entity)
        {
            return base.Add(entity, ProductOnlineValidate);
        }

        private static void ProductOnlineValidate(Product e)
        {
            if (e.IsOnline && e.ProductPrice > 50)
                throw new InvalidOperationException("Invlid price range.");
        }
    }
}