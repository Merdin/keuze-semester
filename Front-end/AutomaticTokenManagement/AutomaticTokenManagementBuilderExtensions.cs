using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

///
/// Adapted from https://github.com/IdentityServer/IdentityServer4.Samples/tree/master/Clients/src/MvcHybridAutomaticRefresh/AutomaticTokenManagement
/// 
namespace FrontEnd.AutomaticTokenManagement
{
    public static class AutomaticTokenManagementBuilderExtensions
    {
        public static AuthenticationBuilder AddAutomaticTokenManagement(this AuthenticationBuilder builder, Action<AutomaticTokenManagementOptions> options)
        {
            builder.Services.Configure(options);
            return builder.AddAutomaticTokenManagement();
        }

        public static AuthenticationBuilder AddAutomaticTokenManagement(this AuthenticationBuilder builder)
        {
            builder.Services.AddHttpClient("tokenClient");
            builder.Services.AddTransient<TokenEndpointService>();

            builder.Services.AddTransient<AutomaticTokenManagementCookieEvents>();
            builder.Services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, AutomaticTokenManagementConfigureCookieOptions>();

            return builder;
        }
    }
}