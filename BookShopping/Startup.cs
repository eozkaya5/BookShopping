using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopping.CustomValidations;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Poco;
using BookShopping.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShopping
{
    public class Startup
    {
        private string _connection = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LoginDbContext>(_ => _.UseSqlServer(Configuration["ConnectionString"]));
            services.AddDbContext<ShoppingDbContext>(_ => _.UseSqlServer(Configuration["ConnectionString"]));
            services.AddSingleton<IConfiguration>(Configuration);
          
            services.AddIdentity<AppUser, AppRole>(_ =>
            {
                _.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
                _.Password.RequireNonAlphanumeric = false;
                _.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+"; //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.
            }).AddDefaultTokenProviders()
                .AddPasswordValidator<CustomPasswordValidation>()
              .AddUserValidator<CustomUserValidation>()
              .AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<LoginDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Security/Index");
                _.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie", //Olu�turulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.                        
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
                };
                _.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(15); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/Home/Errors");

            });
          
            services.AddMvc();
           // services.AddRepositoryService();
           // services.AddHttpContextAccessor();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Errors");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

