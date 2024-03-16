using HRMS.SMTP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.SMTP.Controllers;

[ApiController]
public class EmailController(IEmailService emailService) : ControllerBase
{
    private readonly IEmailService EmailService = emailService;

    [HttpGet("Test")]
    public async Task Test(string message)
        => await EmailService.SendErrorMailAsync(message);
}