using Project_Backend_2024.DTO;

var builder = WebApplication.CreateBuilder(args);

// Load settings
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
builder.Services.AddSingleton(appSettings);

// Add minimal services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Health route
app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    project = appSettings?.ProjectName ?? "Unknown",
    version = appSettings?.Version ?? "Unknown"
}));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

