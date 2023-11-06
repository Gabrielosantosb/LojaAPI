
using Loja.ORM;
using Loja.ORM.Repository.Base;
using Loja.Services.Services.BooksServices;
using Loja.Services.Services.HyperMedia.Enricher;
using Loja.Services.Services.HyperMedia.Filters;
using Loja.Services.Services.PersonServices;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;

namespace Loja.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }



        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;


            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Endereço do Angular
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddControllers();
            //services.AddMvc(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true;

                
            //    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            //    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            //}).AddXmlSerializerFormatters();



            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(connection);

            }
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.Enrichers.Add(new PersonEnricher());
            filterOptions.Enrichers.Add(new BooksEnricher());
            services.AddSingleton(filterOptions);
            
            

            //Versionamento API
            services.AddApiVersioning();

            //Injecao de dependencias
            services.AddScoped<IPersonService, PersonBusinessImplementation>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAngular");
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
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
        private static void MigrateDataBase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "Loja.ORM/DB/migrations", "Loja.ORM/DB/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
