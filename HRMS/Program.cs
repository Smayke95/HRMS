using HRMS.Core.Extensions;
using HRMS.Core.Models.Configurations;
using HRMS.Database.Extensions;
using HRMS.Extensions;
using HRMS.Hubs;
using HRMS.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("HRMS_Database")!);
builder.Services.AddHangfire(builder.Configuration.GetConnectionString("HRMS_Database")!);
builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQ"));

builder.UseSerilog();
builder.Services.AddMemoryCache();

builder.Services.AddScopedRepositories();
builder.Services.AddScopedServices();
builder.Services.AddScopedNotificationServices();
builder.Services.AddScopedStates();

builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter();

var app = builder.Build();

app.Services.DatabaseMigrate();

app.UseHsts();
app.UseHttpsRedirection();

app.UseSwaggerUI();
app.UseHangfireDashboard();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();