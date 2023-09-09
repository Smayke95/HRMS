using HRMS.SMTP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.SMTP.Controllers;

[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService EmailService;

    public EmailController(IEmailService emailService)
    {
        EmailService = emailService;
    }

    [HttpGet("Test")]
    public async Task Test(string message)
        => await EmailService.SendErrorMailAsync(message);
}