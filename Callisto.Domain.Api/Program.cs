using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Callisto.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddTransient<TokenService>();

builder.Services.AddScoped<CallistoContext, CallistoContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserHandler, UserHandler>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<CompanyHandler, CompanyHandler>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<TeamHandler, TeamHandler>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<TicketHandler, TicketHandler>();

builder.Services.AddScoped<IKpiRepository, KpiRepository>();

builder.Services.AddDbContext<CallistoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CallistoConnection"));
});

//Liberar Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // endereço do seu frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

//JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.PrivateKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

app.UseCors("AllowAngular");

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
