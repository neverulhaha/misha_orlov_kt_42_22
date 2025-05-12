using Microsoft.EntityFrameworkCore;
using NLog;
using misha_orlov_kt_42_22.Database;
using NLog.Web;
using misha_orlov_kt_42_22;
using misha_orlov_kt_42_22.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(80);
    });

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDepartmentServices();

    builder.Services.AddDbContext<TeachersDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Stoped programm because of exception");
}
finally
{
    LogManager.Shutdown();
}
