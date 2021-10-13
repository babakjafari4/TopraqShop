using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TopraqShop.Framework.Base.Infrastructure;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductRepository : RepositoryBase<long, ProductBase>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }
    }
}