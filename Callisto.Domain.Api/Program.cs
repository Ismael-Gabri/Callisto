using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<CallistoContext, CallistoContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserHandler, UserHandler>();

builder.Services.AddDbContext<CallistoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CallistoConnection"));
});

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
