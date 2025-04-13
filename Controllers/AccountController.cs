using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpGet("signin-google")]
    public IActionResult SignInGoogle()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        return Challenge(properties, "Google");
    }

    [HttpGet("signin-facebook")]
    public IActionResult SignInFacebook()
    {
        var redirectUrl = Url.Action("FacebookResponse", "Auth");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
        return Challenge(properties, "Facebook");
    }

    [HttpGet("google-response")]
    public async Task<IActionResult> GoogleResponse()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
            return BadRequest("Error loading external login information.");

        // Xử lý đăng nhập hoặc tạo tài khoản mới
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

        if (result.Succeeded)
        {
            // Tạo và trả về JWT token
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
        else
        {
            // Tạo tài khoản mới nếu chưa tồn tại
            var user = new IdentityUser { UserName = info.Principal.FindFirstValue(ClaimTypes.Email), Email = info.Principal.FindFirstValue(ClaimTypes.Email) };
            var createResult = await _userManager.CreateAsync(user);

            if (createResult.Succeeded)
            {
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (addLoginResult.Succeeded)
                {
                    // Tạo và trả về JWT token
                    var token = GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }
            }

            return BadRequest("Error during authentication.");
        }
    }

    [HttpGet("facebook-response")]
    public async Task<IActionResult> FacebookResponse()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
            return BadRequest("Error loading external login information.");

        // Xử lý tương tự như Google
        // ...
        return null;
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        // Triển khai logic tạo JWT token
        // ...
        return null;
    }
}