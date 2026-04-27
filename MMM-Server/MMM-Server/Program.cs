using MMM_Server.Models;
using MMM_Server.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Services
builder.Services.Configure<MMMDatabaseSettings>(builder.Configuration.GetSection("MMMDatabase"));
builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MMM Services Web Server",
        Version = "v3.0",
        Description = "API documentation"
    });
});

var app = builder.Build();

// 2. Middleware Order (CRITICAL)
// We enable Swagger for EVERY environment to ensure it works on Azure
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // The path MUST match the name in SwaggerDoc above ("v1")
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMM API V1");

    // This makes Swagger the default page at https://localhost:7099/
    c.RoutePrefix = string.Empty;

    // 1. Don't expand the model by default (massive speed boost)
    c.DefaultModelExpandDepth(0);

    // 2. Default to showing the 'Schema' instead of the generated 'Example Value'
    // This stops the browser from trying to 'solve' your Regex on click
    c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);

    // 3. Keep everything collapsed until you click it
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);


});

app.UseHttpsRedirection();
app.UseAuthorization();

// 3. Routing
app.MapControllers();

// IMPORTANT: Delete or comment out the MapGet("/") line! 
// If this exists, it "steals" the root URL from Swagger.
// app.MapGet("/", () => Results.Json(new { status = "ok" })); 

app.Run();