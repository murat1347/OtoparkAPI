using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Application.Mapping;
using Otopark.WebAPI.Persistance.Context;
using Otopark.WebAPI.Persistance.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile(),
        new CategoryProfile()
    });
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<OtoparkJwtContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
    }
);
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
