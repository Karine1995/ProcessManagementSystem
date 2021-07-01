using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.BLL._3rdPartyIntegration;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Implementations;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.Common.Constants;
using ProcessManagement.DAL.Infrastructure;

namespace ProcessManagement.BLL
{
    public static class DIConfiguration
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(Constants.ProcessManagementDb);

            services.AddDbContext<ProcessManagementDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            //services
            services.AddScoped<IService, Service>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<ITeamService, TeamService>();
            //3rd party integration services
            services.AddScoped<ProcessManagementIdentityService>();
        }
    }
}
