using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetSL.Api.Services;
using NetSL.Api.Settings;

namespace NetSL.Api
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
            services.AddControllers();

            // Api Versioning
            services.AddApiVersioning(option =>{
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Api HealthChecks
            services.AddHealthChecks()
                .AddCheck("api", () => HealthCheckResult.Healthy(), tags: new[] { "api" });

            // Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetSL API", Version = "v1"});
            });

            // TraficService
            services.AddHttpClient<ITrafficService, TrafficService>(options => {
                options.BaseAddress = new Uri(Configuration.GetValue<string>("SLApiUrl"));
            });

            // Settings file
            IKeySettings settings = new KeySettings(
                Configuration.GetValue<string>("KeySettings:TrafiklageKey"),
                Configuration.GetValue<string>("KeySettings:ReseplanerareKey"),
                Configuration.GetValue<string>("KeySettings:StorningsinformationKey"),
                Configuration.GetValue<string>("KeySettings:RealtidsinformationKey"));
            services.AddSingleton(settings);

            services.AddLogging(options => {
                options.SetMinimumLevel(LogLevel.Information);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetSL API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions() { Predicate = (p) => p.Tags.Contains("api")});
            });
        }
    }
}
