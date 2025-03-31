using Microsoft.AspNetCore.Mvc;
using MAVI.Contracts.Authentication;

namespace MAVI.API.Controller;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Post(LoginRequest request)
    {
        return Ok(request);
    }
}
