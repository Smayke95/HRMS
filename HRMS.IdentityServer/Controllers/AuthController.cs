using HRMS.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace HRMS.IdentityServer.Controllers;

[ApiController]
[Route("[action]")]
public class AuthController(
    IConfiguration configuration,
    IEmployeeRepository employeeRepository)
    : ControllerBase
{
    private readonly IConfiguration Configuration = configuration;
    private readonly IEmployeeRepository EmployeeRepository = employeeRepository;

    [HttpGet]
    public async Task<string> Login(string email, string password)
    {
        var employee = await EmployeeRepository.GetByEmailAndPasswordAsync(email, password);

        if (employee is null)
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return String.Empty;
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecret")!));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, employee.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, employee.Email),
            new Claim(ClaimTypes.Name, employee.FirstName + ' ' + employee.LastName),
            new Claim(ClaimTypes.Email, employee.Email)
        };

        employee.Roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.ToString())));

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}