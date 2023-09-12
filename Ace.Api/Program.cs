using Ace.Api.Database;
using Ace.Api.DataBase;
using Ace.Api.DataBase.Repositories;
using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Services;
using Ace.Shared.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());// JODA for automapper.

string aceConnection = AceConfiguration.InstanceFactory.GetConnectionString("NoteAce");
builder.Services
    .AddEntityFrameworkSqlServer()
        .AddDbContext<AceDbContext>(options =>
        {
            options.UseSqlServer(aceConnection);
#if DEBUG
            options.EnableSensitiveDataLogging(true);
#endif
        })
        .AddTransient<IPropertyMappingService, PropertyMappingService>()
        .AddScoped<IMemberRepository, MemberRepository>()
        .AddScoped<IFamilyRepository, FamilyRepository>()
        .AddScoped<INotificationRepository, NotificationRepository>()
        .AddScoped<ICommunityRepository, CommunityRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
