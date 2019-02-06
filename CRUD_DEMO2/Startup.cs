using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CRUD_DEMO2.Model;

using CRUD_DEMO2.Repository;
using CoreServices.Repository;

namespace CRUD_DEMO2
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddDbContext<IronManContext>(options =>
           // options.UseMySql(Configuration.GetConnectionString("DataAccessPostgreSqlProvider")));

           // services.AddDbContext<DBContext>(item => item.UseNpgsql
                          //  (Configuration.GetConnectionString("DataAccessPostgreSqlProvider")));
            //services.AddScoped<REpo, BloggerRepository>();
            services.AddDbContext<DBContext>(options => options.UseNpgsql
            (Configuration.GetConnectionString("DataAccessPostgreSqlProvider")));

            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IIntentRepository, IntentRepository>();
            services.AddScoped<IUtterencesRepository, UtterencesRepository>();

            Console.WriteLine("db connection done");
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
