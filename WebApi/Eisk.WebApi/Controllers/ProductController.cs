using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eisk.Core.WebApi;
using Eisk.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.WebApi.Controllers
{
    using Core.DomainService;
    using Domains.Entities;
    using Eisk.Core.WebApi;

    [Route("api/[controller]")]
    public class ProductController
    :WebApiControllerBase<Product,int>
    {
        public ProductController(
            DomainService<Product, int>
                productDomainService)
            : base(productDomainService)
        {

        }
    }
}

