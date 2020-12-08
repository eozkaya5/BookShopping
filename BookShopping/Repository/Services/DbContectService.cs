using BookShopping.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Repository
{
    static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            services.AddDbContext<ShoppingDbContext>(x => x.UseSqlServer("Data Source=ELIF_OZKAYA\\SQLEXPRESS;Initial Catalog=BookShopping;Integrated Security=True"));
            return services;
        }
    }


}
