using Autofac;
using Autofac.Extensions.DependencyInjection;
using EvaExchange.Business.DependencyResolvers.Autofac;
using EvaExchange.Business.Services;
using EvaExchange.Infrastructure.Interface;
using EveExchange.DataAccess.Abstract;
using EveExchange.DataAccess.Concrete;
using EveExchange.DataAccess.Entitiy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
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
