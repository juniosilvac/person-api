using Core.Person.Model.Context;
using Core.Person.Business;
using Core.Person.Business.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Person.Repository;
using Core.Person.Repository.Implementations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Core.Person.Generic;

namespace Person.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger _logger;
        public IHostingEnvironment _environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options=> options.UseMySql(connectionString));

            if(_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnetion = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnetion, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string>
                        {
                            "db/migrations"                            
                        },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch(Exception err)
                {
                    _logger.LogCritical("Database migration failed.", err);
                    throw;
                }
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning();


            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();

            loggerFactory.AddConsole(_configuration.GetSection("Loggin"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}
