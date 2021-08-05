using AuthenticationPlugin;
using EShopApi.DTOs;
using EShopApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Infrastructure.Identity;
using System.Threading.Tasks;

namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthService _auth;

        public UsersController(UserManager<ApplicationUser> userManager, AuthService auth)
        {
            _userManager = userManager;
            _auth = auth;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginCredential loginCredential)
        {
            var user = await _userManager.FindByEmailAsync(loginCredential.Email);

            if (user == null)
            {
                return NotFound($"Unable to load user with Email '{loginCredential.Email}'.");
            }

            if (_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginCredential.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Failed to login!");
            }

            var userRole = await _userManager.GetRolesAsync(user);

            var token = new ConfigureToken();
            return token.GenerateToken(loginCredential, userRole, _auth);
        }
    }
}
