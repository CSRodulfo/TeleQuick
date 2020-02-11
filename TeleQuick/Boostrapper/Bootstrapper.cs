using DataAcces.Core;
using DataAccess;
using IDataAccess;
using IDataAccess.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace Boostrapper
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Business Services
            //services.AddScoped<IEmailSender, EmailSender>();

            // Repositories
            services.AddHttpContextAccessor();
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<ICustomerService, CustomerService>();
           // services.AddScoped<IDataAccess, CustomerService>();


            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(Authorization.Policies.ViewAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ViewUsers));
            //    options.AddPolicy(Authorization.Policies.ManageAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ManageUsers));

            //    options.AddPolicy(Authorization.Policies.ViewAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ViewRoles));
            //    options.AddPolicy(Authorization.Policies.ViewRoleByRoleNamePolicy, policy => policy.Requirements.Add(new ViewRoleAuthorizationRequirement()));
            //    options.AddPolicy(Authorization.Policies.ManageAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ManageRoles));

            //    options.AddPolicy(Authorization.Policies.AssignAllowedRolesPolicy, policy => policy.Requirements.Add(new AssignRolesAuthorizationRequirement()));
            //});

            return services;
        }
    }
}
