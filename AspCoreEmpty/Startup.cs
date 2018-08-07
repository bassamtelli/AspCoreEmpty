using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace AspCoreEmpty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<ICountryRepository>(new CountryRepository());
        //    //services.AddDirectoryBrowser();
        //    services.AddMvc();
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ICountryRepository country)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseStaticFiles();
        //        app.UseMvcWithDefaultRoute();
        //    }

        //    app.Run(async (context) =>
        //    {

        //        await context.Response.WriteAsync("hello world");
        //    });
        //}
        public Startup(IHostingEnvironment env)

        {

            var builder = new ConfigurationBuilder()

            .SetBasePath(env.ContentRootPath)

            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

            .AddJsonFile($"appsettings.{env.EnvironmentName} .json", optional: true)

            .AddEnvironmentVariables();

            Configuration = builder.Build();

        }



        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)

        {

            services.AddMvc();



            var connectionString = Configuration["DbContextSettings:ConnectionString"];

            services.AddDbContext<StudentContext>(opts => opts.UseNpgsql(connectionString));

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)

        {

            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

            }



            app.UseMvc();



        }

    }

}
