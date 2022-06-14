using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using ShoppingCart.Api.Contexts;
using ShoppingCart.Api.Repositories.Implementation;
using ShoppingCart.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ShoppingCart.Api
{
   public class Startup
   {
      public Startup(IWebHostEnvironment env)
      {
         var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
         Configuration = builder.Build();
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         // For testing purposes use an in memory database
         // Swap out for another such as SqlServer
         services.AddDbContext<ApiDbContext>(options => { options.UseInMemoryDatabase("Test"); });

         services.AddScoped<ICatalogRepository, CatalogRepository>();
         services.AddScoped<ICartRepository, CartRepository>();

         // Ensure lower case URLs for routing
         services.AddRouting(opt => opt.LowercaseUrls = true);
         services.AddControllers();

         services.AddAutoMapper();
         services.AddMvc();
         //services.AddMvc(opt =>
         //{
         //    opt.AllowEmptyInputInBodyModelBinding = true;
         //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

         // Register the Swagger generator, defining 1 or more Swagger documents
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "ShoppingCart.Api", Version = "v1"});
            //c.CustomSchemaIds((type) => type.SwaggerName());

            var xmlFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
         });
         services.AddApplicationInsightsTelemetry();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            //TestData.Seed(app).Wait();

            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCart.Api");
               c.RoutePrefix = string.Empty;
            });
         }
         else
         {
            app.UseHsts();
         }

         app.UseRouting();
         app.UseSwagger();
         app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 api test");
         });

         app.UseHttpsRedirection();
         //app.UseMvc();
         app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
      }
   }
}