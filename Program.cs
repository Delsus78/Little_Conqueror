using System.Text.Json;
using Little_Conqueror.Exceptions;
using Little_Conqueror.Helpers.JsonConverters;
using Little_Conqueror.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        Console.Out.WriteLine("Adding cors policy");
        corsPolicyBuilder.WithOrigins("http://localhost:5173", "https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Important pour SignalR
    });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AppExceptionFiltersAttribute>();
});

// Services
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<INominatimOSMService, NominatimOSMService>();


// HttpClients
builder.Services.AddHttpClient("NominatimOSM", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://nominatim.openstreetmap.org/");
    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Little_Conqueror/1.0");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers()
    .WithOpenApi();

app.Run();
