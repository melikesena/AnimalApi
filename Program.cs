using AnimalApi.Interfaces;
using AnimalApi.Models;
using AnimalApi.Services;


var builder = WebApplication.CreateBuilder(args);

// MongoDB ayarlarını al
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);

// DI kayıtları
builder.Services.AddSingleton<IAnimalService, AnimalService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
