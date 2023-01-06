using WebApp;
using WebApp.Extensions;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
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