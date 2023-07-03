using HRMS.Core.Extensions;
using HRMS.Core.Models.Configurations;
using HRMS.Database.Extensions;
using HRMS.Extensions;
using SenseOfUrgency.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("HRMS_Database")!);
builder.Services.AddHangfire(builder.Configuration.GetConnectionString("HRMS_Database")!);
builder.Services.Configure<SmtpConfiguration>(builder.Configuration.GetSection("SmtpConfiguration"));

builder.Services.AddMemoryCache();

builder.Services.AddScopedRepositories();
builder.Services.AddScopedServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHangfireDashboard(builder.Configuration);
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();