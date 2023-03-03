// Startup.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 14

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Server;

namespace Ark.Vinke.Server
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
            IMvcBuilder iMvcBuilder = services.AddControllers();

            // Add ark modules as part of the application
            String[] arkServerAssemblyArray = Directory.GetFiles(LibDirectory.Root.Bin.Path, "*.Server.dll", SearchOption.AllDirectories);
            foreach (String arkServerAssembly in arkServerAssemblyArray)
                iMvcBuilder.AddApplicationPart(Assembly.LoadFrom(arkServerAssembly));

            // Add Mvc options
            services.AddMvc(options =>
            {
                // Add Filters
                options.Filters.Add(typeof(LibAuthorizationServer));

                // Add InputFormatters
                options.InputFormatters.Insert(0, new LibFormattersInputServer());

                // Add OutputFormatters
                options.OutputFormatters.Insert(0, new LibFormattersOutputServer());
            });

            // Add cors default policy
            services.AddCors(options => { options.AddDefaultPolicy(builder => { }); });

            // Add hosted services
            services.AddHostedService<LibTimedHostedServer>();
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

            // Add Preflight to the pipeline
            app.UseMiddleware<LibPreflightServer>();

            // Add authentication to the pipeline
            app.UseMiddleware<LibAuthenticationServer>();

            // Enabled cors
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
