using MMM_Server.Models;
using MMM_Server.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MMMDatabaseSettings>(builder.Configuration.GetSection("MMMDatabase"));
builder.Services.AddSingleton<PersonalProfileService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<ProcessActionService>();
builder.Services.AddSingleton<TransactService>();
builder.Services.AddSingleton<WalletService>();
builder.Services.AddSingleton<MessageService>();
builder.Services.AddSingleton<RightService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<BasicObjectService>();
builder.Services.AddSingleton<ObjectService>();
builder.Services.AddSingleton<BasicMLocationService>();
builder.Services.AddSingleton<MLocationService>();
builder.Services.AddSingleton<AuthenticationService>();
builder.Services.AddSingleton<AssetService>();
builder.Services.AddSingleton<DiscoveryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MMM Services Web Server",
        Version = "v2.0",
        Description = "API documentation for MMM Services Web Server" 
    });
});

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
