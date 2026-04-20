using ConversaoAPI.Clients;
using ConversaoAPI.Clients.Interfaces;
using ConversaoAPI.Services;
using ConversaoAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IFrankfurterClient, FrankfurterClient>(client =>
{
    client.BaseAddress = new Uri("https://api.frankfurter.app/");
});

builder.Services.AddScoped<IConversaoService, ConversaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.Run();
