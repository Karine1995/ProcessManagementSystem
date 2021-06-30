using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessManagement.IdentityServer4.Common.Models.Inputs;
using ProcessManagement.IdentityServer4.Data.Entities;
using ProcessManagement.IdentityServer4.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagement.IdentityServer4.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var user = new ApplicationUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Email
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
                return IdentityResponse(result);

            return Ok(user.Id);
        }
    }
}
