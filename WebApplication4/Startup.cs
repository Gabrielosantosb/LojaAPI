using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using WebApplication4.Business;
using WebApplication4.Business.Implementations;
using WebApplication4.Model.Context;
using WebApplication4.Repository.Base;
using WebApplication4.Repository.Implementations;


namespace WebApplication4
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

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(connection);

            }
            //Versionamento API
            services.AddApiVersioning();
            //Injecao de dependencia
            services.AddScoped<IPersonService, PersonBusinessImplementation>();
            services.AddScoped<IBookService, BooksServiceImplementation>();
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
            });
        }
        private void MigrateDataBase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
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
