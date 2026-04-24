using ECommerce.Application.Services.Authentication;
using ECommerce.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResult>> Register(RegisterRequest request)
    {
        try
        {
            var result = await authenticationService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            
            var response = new AuthenticationResult(
                result.Id,
                result.FirstName,
                result.LastName,
                result.Email,
                result.Token
                );

            return Ok(response);
        }
        catch(InvalidOperationException ex)
        {
            return BadRequest(new {message = ex.Message});
        }
        
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> Login(LoginRequest request)
    {
        try
        {
            var result = authenticationService.LoginAsync(
                request.Email, 
                request.Password);
            
            var response = new AuthenticationResult(
                result.Result.Id,
                result.Result.FirstName,
                result.Result.LastName,
                result.Result.Email,
                result.Result.Token
            );
            
            return Ok(response);
        }
        catch(UnauthorizedAccessException ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }
}