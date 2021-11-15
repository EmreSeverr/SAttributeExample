using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAttributeExample.Data;
using Microsoft.EntityFrameworkCore;
using SAttributeExample.Data.Repo.Abstract;
using SAttributeExample.Data.Repo.Concrate;
using Microsoft.AspNetCore.Http;
using SAttributes.Extensions;

namespace SAttributeExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SAttributeContext>(options => options.UseMySql(Configuration["ConnectionStrings:LocalDatabase"].ToString(), new MySqlServerVersion(new Version(1, 0, 0)), o => { o.MigrationsAssembly("SAttributeExample"); }));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.ConfigureSAttributes();

            services.AddControllers();

            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
