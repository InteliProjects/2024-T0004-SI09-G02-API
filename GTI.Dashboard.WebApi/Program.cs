using GTI.Dashboard.Repository;
using GTI.Dashboard.Services.CID;
using GTI.Dashboard.Services.Employees;
using GTI.Dashboard.Services.GPTW;
using GTI.Dashboard.Services.HealthInsurance;
using GTI.Dashboard.Services.Logging;
using GTI.Dashboard.Services.Logs;
using GTI.Dashboard.Services.Organization;
using GTI.Dashboard.Services.Stiba;
using GTI.Dashboard.Services.Zenklub;
using GTI.Dashboard.WebApi;
using ikvm.runtime;
using Microsoft.AspNetCore.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = configBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository>(_ => new EmployeeRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();
builder.Services.AddScoped<IHealthInsuranceRepository>(_ => new HealthInsuranceRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<ICIDService, CIDService>();
builder.Services.AddScoped<ICIDRepository>(_ => new CIDRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IGPTWService, GPTWService>();
builder.Services.AddScoped<IGPTWRepository>(_ => new GPTWRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IStibaService, StibaService>();
builder.Services.AddScoped<IStibaRepository>(_ => new StibaRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IZenklubService, ZenklubService>();
builder.Services.AddScoped<IZenklubRepository>(_ => new ZenklubRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IOrganizationRepository>(_ => new OrganizationRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<ILogService, LogsService>();
builder.Services.AddScoped<ILogRepository>(_ => new LogRepository(configuration["DB_CONFIG"]));

//Log.Logger = new LoggerConfiguration().
//ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();