using Domain;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using update.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependecy inyection
builder.Services.AddScoped<IActivityInfrastructure, ActivityInfrastructure>();
builder.Services.AddScoped<IActivityDomain, ActivityDomain>();

builder.Services.AddScoped<ICommunityInfrastructure, CommunityInfrastructure>();
builder.Services.AddScoped<ICommunityDomain, CommunityDomain>();

builder.Services.AddScoped<IParticipationInfrastructure, ParticipationInfrastructure>();
builder.Services.AddScoped<IParticipationDomain, ParticipationDomain>();

builder.Services.AddScoped<ILocationInfrastructure, LocationInfrastructure>();
builder.Services.AddScoped<ILocationDomain, LocationDomain>();

//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("upDateConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<UpdateDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel)
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<UpdateDbContext>())
{
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();