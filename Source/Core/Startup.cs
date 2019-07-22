/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Dolittle.AspNetCore.Bootstrap;
using Dolittle.AspNetCore.Debugging.Swagger;
using Dolittle.Booting;
using Dolittle.DependencyInversion.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Read.Locations.Nodes;
using Swashbuckle.AspNetCore.Swagger;

namespace Core
{
    public partial class Startup
    {
        readonly IHostingEnvironment _hostingEnvironment;
        readonly ILoggerFactory _loggerFactory;
        BootloaderResult _bootResult;

        public Startup(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                services.AddDolittleSwagger();

                services.AddCors();
            }
            services.AddMvc();

            _bootResult = services.AddDolittle(_loggerFactory);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) => {
                AllNodes.Tenant = context.Request.Headers.ContainsKey("tenant") ? 
                                                Guid.Parse(context.Request.Headers["tenant"].First()) :
                                                Guid.Empty;

                AllNodes.Microservice = context.Request.Headers.ContainsKey("microservice") ? 
                                                Guid.Parse(context.Request.Headers["microservice"].First()) :
                                                Guid.Empty;

                AllNodes.Correlation = context.Request.Headers.ContainsKey("correlation") ? 
                                                context.Request.Headers["correlation"].First() :
                                                string.Empty;
                                                
                await next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDolittleSwagger();

                app.UseCors(_ => {
                    _.AllowCredentials();
                    _.AllowAnyMethod();
                    _.AllowAnyOrigin();
                    _.AllowAnyHeader();
                });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseWebSockets(new WebSocketOptions 
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4*1024
            });
            app.UseDolittle();
            app.RunAsSinglePageApplication();
        }
    }
}