using MMM_Server.Models;
using MMM_Server.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MMMDatabaseSettings>(builder.Configuration.GetSection("MMMDatabase"));
builder.Services.AddSingleton<AccountService>();


// Add the controllers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MMM Services Web Server",
        Version = "v3.0",
        Description = "API documentation for MMM Services Web Server" 
    });
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // This makes Swagger appear at the root URL (https://mmm-server...azurewebsites.net/)
    options.RoutePrefix = string.Empty;
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/", () => Results.Json(new { status = "ok", version = "v3.0", message = "MMM Services Web Server is running" }));

app.Run();
