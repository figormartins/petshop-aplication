using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Petshop.Api.Persistence;
using Petshop.Api.Repositories.Accommodation;
using Petshop.Api.Repositories.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Petshop API", Version = "1.0.0" })
            );

            services.AddCors();

            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<PetshopDbContext>(options =>
                options.UseInMemoryDatabase("PetshopDb"));

            //services.AddDbContext<PetshopDbContext>(options =>
            //    options.UseNpgsql(connectionString)
            //);

            services.AddTransient<IAccommodationRepository, AccommodationRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.WithOrigins("http://localhost:333")
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Petshop API");
            });

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
