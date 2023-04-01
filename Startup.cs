using Bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
#pragma warning disable IDE0005 // Using directive is unnecessary.
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
#pragma warning restore IDE0005 // Using directive is unnecessary.
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models.Repositories;
using Bookstore.Models.Repositories.Repo;

namespace Bookstore
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Func<RequestDelegate, RequestDelegate> HellowWorldMiddleware { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IRepository<Book>, BookDbRepository>();
            services.AddScoped<IRepository<Author>, AuthorDbRepository>();
            services.AddScoped<IRepository<Customer>, CustomerDbRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddScoped<ICustomer,Customer>();  
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<BookstoreDbContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
            });
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
           
            // Middlewares محطات المعالجه المتقدمه
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
