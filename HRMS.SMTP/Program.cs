using HRMS.SMTP.Extensions;
using HRMS.SMTP.Interfaces;
using HRMS.SMTP.Models;
using HRMS.SMTP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.Configure<MailSlurpConfiguration>(builder.Configuration.GetSection("MailSlurp"));

builder.UseSerilog();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.Services.GetRequiredService<IEmailService>();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();