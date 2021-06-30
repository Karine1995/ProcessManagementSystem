using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.IdentityServer4.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagement.IdentityServer4.Configurations
{
    internal static partial class InitializeDbConfiguration
    {
        public static async Task InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            await serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();
            await serviceScope.ServiceProvider.GetRequiredService<ProcessManagementIdentityDbContext>().Database.MigrateAsync();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            await context.Database.MigrateAsync();

            if (!context.Clients.Any())
            {
                foreach (var client in Clients)
                    context.Clients.Add(client.ToEntity());

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in IdentityResources)
                    context.IdentityResources.Add(resource.ToEntity());

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var scope in ApiScopes)
                    context.ApiScopes.Add(scope.ToEntity());

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in ApiResources)
                    context.ApiResources.Add(resource.ToEntity());

                context.SaveChanges();
            }
        }
    }
}
