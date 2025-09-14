using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Data;
using VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllAuthorsRequestViewModel).Assembly));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<GetAllAuthorsRequestViewModel>();

// Register the generic parameters for your endpoints
builder.Services.AddScoped(typeof(EndPointBaseParameters<>));

// DbContext (you already have this)
builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connString")));
// Add Request Handler Base
builder.Services.AddScoped<RequestHandlerBaseParameters>();
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
