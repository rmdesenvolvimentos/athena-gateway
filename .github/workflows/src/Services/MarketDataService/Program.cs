var builder = WebApplication.CreateBuilder(args);

// Aggiunge il supporto per Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint di benvenuto
app.MapGet("/", () => "Welcome to Athena Gateway - MarketDataService!");

// Endpoint di Health Check
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy" }))
   .WithName("GetHealthCheck")
   .WithTags("Monitoring");

app.Run();
