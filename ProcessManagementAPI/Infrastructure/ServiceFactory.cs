using ProcessManagement.BLL.Services.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.BLL._3rdPartyIntegration;

namespace ProcessManagementAPI.Infrastructure
{
    /// <summary>
    /// Get BLL services
    /// </summary>
    public class ServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ServiceFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        /// <summary>
        /// User service
        /// </summary>
        public IUserService UserService => _serviceProvider.GetService<IUserService>();

        /// <summary>
        /// Project service
        /// </summary>
        public IProjectService ProjectService => _serviceProvider.GetService<IProjectService>();

        /// <summary>
        /// Assignment service
        /// </summary>
        public IAssignmentService AssignmentService => _serviceProvider.GetService<IAssignmentService>();

        /// <summary>
        /// Team service
        /// </summary>
        public ITeamService TeamService => _serviceProvider.GetService<ITeamService>();

        /// <summary>
        /// Process management identity service
        /// </summary>
        public ProcessManagementIdentityService ProcessManagementIdentityService => _serviceProvider.GetService<ProcessManagementIdentityService>();
    }
}
