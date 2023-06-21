using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
    {
        var response = await _authenticationService.Register(
            new User { Email = request.Email },
            request.Password
        );

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin loginRequest)
    {
        var response = await _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password
        );

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("change-password"), Authorize]
    public async Task<ActionResult<ServiceResponse<bool>>> ChangePasword(
        [FromBody] string newPassword
    )
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _authenticationService.ChangePassword(int.Parse(userId), newPassword);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
