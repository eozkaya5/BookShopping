using BookShopping.Models.ShoppingModel;
using BookShopping.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Repository
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //  services.AddTransient<IRepository<Basket>>(x => new BasketRepository());
            // services.AddTransient<IRepository<Product>>(x => new ProductRepository());

            return services;
        }
    }
}

