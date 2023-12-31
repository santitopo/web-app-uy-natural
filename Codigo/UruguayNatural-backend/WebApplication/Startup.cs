using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters;
using Logic;
using LogicInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using PersistenceInterface;

namespace WebApplication
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
            services.AddCors(cors =>
            {
                cors.AddPolicy("UruguayNaturalPolicy", options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<DbContext, UyNaturalContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("Obligatorio1DA2"))
            );
            //Dependency injection Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ITPointRepository), typeof(TPointRepository));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(ILodgingRepository), typeof(LodgingRepository));
            services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
            //Dependency injection Logic Interfaces
            services.AddScoped<ISearchLogic, SearchLogic>();
            services.AddScoped<ILodgingLogic, LodgingLogic>();
            services.AddScoped<IAdminLogic, AdminLogic>();
            services.AddScoped<IReservationLogic, ReservationLogic>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IPriceCalculator, PriceCalculatorRetired>();

            services.AddScoped<AuthorizationFilter>();
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

            app.UseCors("UruguayNaturalPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
