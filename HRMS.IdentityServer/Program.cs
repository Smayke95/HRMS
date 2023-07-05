using HRMS.Core.Extensions;
using HRMS.Database.Extensions;
using HRMS.IdentityServer.Extensions;
using IdentityServer4.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("HRMS_Database")!);

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(new List<ApiScope> { new ApiScope() })
    .AddInMemoryClients(new List<Client> { new Client() });

builder.Services.AddScopedRepositories();
builder.Services.AddScopedServices();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseIdentityServer();
app.MapControllers();

app.Run();