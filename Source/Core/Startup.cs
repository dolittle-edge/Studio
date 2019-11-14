/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Autofac;
using Dolittle.AspNetCore.Bootstrap;
using Dolittle.AspNetCore.Debugging.Swagger;
using Dolittle.Booting;
using Dolittle.Concepts.Serialization.Json;
using Dolittle.DependencyInversion.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            //     services.AddSwaggerGen(c =>
            //     {
            //         c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //     });

                services.AddCors();
                services.AddDolittleSwagger();
            }
            services.AddMvc().AddJsonOptions(_ => _.SerializerSettings.Converters.Add(new ConceptConverter()));

            _bootResult = services.AddDolittle(_loggerFactory);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c =>
                // {
                //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                // });

                app.UseCors(_ =>
                {
                    _.AllowCredentials();
                    _.AllowAnyMethod();
                    _.AllowAnyOrigin();
                    _.AllowAnyHeader();
                });
                app.UseDolittleSwagger();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();


            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            });
            app.UseDolittle();
            app.RunAsSinglePageApplication();
        }
    }
}