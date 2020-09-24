using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using VehicleMaintenceService.API.Helpers.Filters;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using VehicleMaintenceService.API.HealthChecks;
using System.Web;
using Inseego.Services;
using VehicleMaintenceService.API.Middleware;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace VehicleMaintenceService
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
            services.RegisterService();
            services.AddHealthChecks() // see https://medium.com/it-dead-inside/implementing-health-checks-in-asp-net-core-a8331d16a180
                    .AddCheck<HealthyCheck>("Overall");

            var redisConfiguration = new RedisConfiguration()
            {
                Hosts = new RedisHost[]
                {
                 new RedisHost()
                 {
                    Host =  Inseego.Utilities.Models.Configuration.Redishost,
                    Port = Convert.ToInt32(Inseego.Utilities.Models.Configuration.Redisport)
                 }
                },
                Ssl = true,
                AbortOnConnectFail = false,
                Password = Inseego.Utilities.Models.Configuration.Rediskey,
                ConnectTimeout = Inseego.Utilities.Models.Configuration.RedisTimeout,
                AllowAdmin = Inseego.Utilities.Models.Configuration.RedisAllowAdmin
            };
            services.AddSingleton(redisConfiguration);
            services.AddSingleton<IRedisCacheClient, RedisCacheClient>();
            services.AddSingleton<IRedisCacheConnectionPoolManager, RedisCacheConnectionPoolManager>();
            services.AddSingleton<ISerializer, NewtonsoftSerializer>();

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ValidateModelStateAttribute));
                config.RespectBrowserAcceptHeader = true; // Returns 406 if client tries to negotiate for media type server does not support.
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Title = "Vehicle Maintence Service",
                        Description = "Inseego Dashboard Service"
                    });
                    //c.OperationFilter<RequiredAuthHeaders>();
                    c.EnableAnnotations();
                    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                    xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseCors("CorsPolicy");

            app.Use(async (context, next) =>
            {
                if (context.Request.QueryString.HasValue)
                {
                    if (string.IsNullOrWhiteSpace(context.Request.Headers["x-tenant"]))
                    {
                        var queryString = HttpUtility.ParseQueryString(context.Request.QueryString.Value);
                        string tenant = queryString.Get("x-tenant");
                        string user = queryString.Get("x-user");
                        string ocpApim = queryString.Get("Ocp-Apim-Subscription-Key");
                        if (!string.IsNullOrWhiteSpace(tenant))
                        {
                            context.Request.Headers.Add("x-tenant", new[] { tenant });
                        }
                        if (!string.IsNullOrWhiteSpace(user))
                        {
                            context.Request.Headers.Add("x-user", new[] { user });
                        }
                    }
                }

                await next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
           // app.UseMiddleware<RequestResponseMiddleware>();
            app.UseMvc();

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                ResponseWriter = WriteHealthCheckResponse // //that's our custom method that writes the health response
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard Service");
                }
            );
        }

        /// <summary>
        /// Health check information: https://medium.com/it-dead-inside/implementing-health-checks-in-asp-net-core-a8331d16a180
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        private static Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport report)
        {
            string json = Inseego.Utils.Shared.HealthStatusFormatter.FormatAsJSON(report);
            return httpContext.Response.WriteAsync(json);
        }
    }
}