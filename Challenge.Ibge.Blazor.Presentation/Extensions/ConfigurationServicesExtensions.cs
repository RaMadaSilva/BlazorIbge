using Challenge.Ibge.Blazor.Applications.Interfaces;
using Challenge.Ibge.Blazor.Applications.Services;
using Challenge.Ibge.Blazor.Domain.Interfaces;
using Challenge.Ibge.Blazor.Infra.Data;
using Challenge.Ibge.Blazor.Infra.Repositories;
using Challenge.Ibge.Blazor.Presentation.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Ibge.Blazor.Presentation.Extensions
{
    public static class ConfigurationServicesExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddRazorComponents()
                .AddInteractiveServerComponents();

            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            return services; 
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<ILocalityService, LocalityService>();
            services.AddScoped<ILocalityRepository, LocalityRepository>(); 
            services.AddScoped<ILocalityRemovedRepository, LocalityRemovedRepository>();

            return services; 
        }
    }
}
