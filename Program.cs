using AnimalApi.Interfaces;
using AnimalApi.Services;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    WebRootPath = "wwwroot",
    EnvironmentName = Environments.Development
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Her IP'den bağlanılabilir
});

builder.Services.AddControllers();
builder.Services.AddSingleton<IAnimalService, AnimalService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
