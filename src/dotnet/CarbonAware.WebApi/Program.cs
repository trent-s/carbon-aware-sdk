using CarbonAware;
using CarbonAware.Aggregators.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CarbonAwareVariablesConfiguration>(builder.Configuration.GetSection(CarbonAwareVariablesConfiguration.Key));
builder.Services.AddCarbonAwareEmissionServices(builder.Configuration);
builder.Services.AddCarbonAwareSciScoreServices(builder.Configuration);

builder.Services.AddHealthChecks();

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

app.MapHealthChecks("/health");

app.Run();