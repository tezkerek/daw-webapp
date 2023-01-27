using WebApp;
using WebApp.Extensions;
using WebApp.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<AppSettings>();
builder.Services.Configure<AppSettings>(builder.Configuration);

var appSettings = builder.Configuration.Get<AppSettings>()!;

builder.Services.SetupScopedServices();
builder.Services.SetupDatabase(appSettings);
builder.Services.SetupIdentity();
builder.Services.SetupJwtAuthentication(appSettings);

builder.Services.AddTransient<AppSeeder>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var seedTask = app.UseSeeder();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

    await seedTask;
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();