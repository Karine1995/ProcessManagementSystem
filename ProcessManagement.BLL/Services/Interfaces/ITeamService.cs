using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface ITeamService : IService
    {
        Task<TeamDTO> CreateAsync(CreateTeamInput createTeamInput);
    }
}
