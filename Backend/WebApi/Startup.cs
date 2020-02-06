using Autofac;
using AutoMapper;
using Common.Configuration;
using Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.Globalization;
using System.Threading;
using WebAPI.CustomSecurity;
using WebApi.ExceptionHandler;

namespace WebApi
{
    public class Startup
    {
        private readonly Bootstrapper.Startup boostrapperStartup;

        private readonly AppConfiguration appConfiguration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.boostrapperStartup = new Bootstrapper.Startup(configuration);
            this.appConfiguration = new AppConfiguration(this.Configuration);
            this.boostrapperStartup.ConfigureSerilog();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.boostrapperStartup.ConfigureServices(services);

            services.AddAutoMapper(typeof(DataMappingProfile).Assembly);

            services.Configure<AppOptions>(this.Configuration.GetSection("AppConfiguration"));

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            _ = services.AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = CustomAuthOptions.DefaultScheme;
                  options.DefaultChallengeScheme = CustomAuthOptions.DefaultScheme;
              });

            // Call custom authentication extension method
            //.AddCustomAuth(options =>
            //{
            //    //options.AuthKey = "Farmacity";
            //});
            services.AddMvc(options =>
            {
                // All endpoints need authentication || el que no se necesite se debe especificar [AllowAnonymous]
                //options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }).AddMvcOptions(o =>
            {
                o.Filters.Add(new GlobalExceptionFilter());
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Farmacity", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            this.boostrapperStartup.ConfigureContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"../{c.RoutePrefix}/v1/swagger.json", "API Farmacity");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
