using Context;
using Microsoft.EntityFrameworkCore;
using SuitableVtbBranches.AppStart;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Cors",
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:7100")
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddDbContext<DataContext>(options => 
                                                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
