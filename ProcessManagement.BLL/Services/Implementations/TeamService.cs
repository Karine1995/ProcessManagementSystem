using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Mappers.Infrastructure;
using System.Threading.Tasks;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class TeamService : Service, ITeamService
    {
        public TeamService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TeamDTO> CreateAsync(string name)
        {
            var team = new Team() { Name = name };

            await DbContext.Teams.AddAsync(team);
            await DbContext.SaveChangesAsync();

            return team.MapTo<TeamDTO>();
        }
    }
}
