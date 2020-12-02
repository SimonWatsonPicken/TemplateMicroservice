using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Handlers;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using TemplateMicroservice.Domain.Providers;
using TemplateMicroservice.Infrastructure;
using TemplateMicroservice.Infrastructure.Providers.SampleProvider;

namespace TemplateMicroservice.Api
{
    [ExcludeFromCodeCoverage]
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Template Microservice API",
                    Description = "A simple example ASP.NET Core Web API based on DDD principles",
                    Contact = new OpenApiContact
                    {
                        Name = "Simon Watson-Picken",
                        Email = "swatsonpicken@gmail.com"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            services.Configure<SampleCredentialsOptions>(Configuration.GetSection(SampleCredentialsOptions.SampleCredentials));
            services.AddOptions<SampleCredentialsOptions>();

            services.AddScoped<ICommandHandler<SampleCommand>, SampleCommandHandler>();
            services.AddScoped<IProvider<Author>, SampleProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template Microservice API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}