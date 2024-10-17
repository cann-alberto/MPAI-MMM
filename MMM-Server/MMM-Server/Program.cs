using MMM_Server.Models;
using MMM_Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MMMDatabaseSettings>(builder.Configuration.GetSection("MMMDatabase"));
builder.Services.AddSingleton<PersonalProfileService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<DeviceService>();
builder.Services.AddSingleton<PersonaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
