using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NsbBug;
using System;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
});

var nsb = new NServicebusConfiguration()
    .Configure(builder.Services);

builder.Services
   .AddTransient<IService, Service>();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();