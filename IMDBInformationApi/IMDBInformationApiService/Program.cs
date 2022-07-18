using IMDBInformation.Domain;
using IMDBInformation.Repository.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.DataConfigurations();
builder.Services.AddControllers();
AppSettings.AssignAppSettings(builder.Configuration);
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
