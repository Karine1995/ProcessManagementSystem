using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Mappers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessManagement.Entities.Models;
using ProcessManagement.BLL.Validators.Teams;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class TeamService : Service, ITeamService
    {
        public TeamService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TeamDTO> CreateAsync(CreateTeamInput createTeamInput)
        {
            var Team = createTeamInput.MapTo<Team>();
            var validator = new CreateTeamValidator(DbContext);
            await validator.ValidateAsync(Team);

            await DbContext.Teams.AddAsync(Team);
            await DbContext.SaveChangesAsync();

            return Team.MapTo<TeamDTO>();
        }
    }
}
