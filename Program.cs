using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
});

//next two lines will make NSB fail
var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
System.Reflection.Assembly.LoadFile(path);


var endpointConfiguration = new NServiceBus.EndpointConfiguration("Something");
var transport = endpointConfiguration.UseTransport<LearningTransport>();
EndpointWithExternallyManagedServiceProvider.Create(endpointConfiguration, builder.Services);

builder.Services.AddTransient<MyService>();
builder.Services.AddControllers();

try
{
    //prints IOC container
    builder.Services.Select(x => x.ServiceType.ToString())
        .OrderBy(x => x)
        .ToList().ForEach(x => Console.WriteLine(x));

    var app = builder.Build();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


public class MyService { }
public class MyMessage : ICommand { }

public class MyMessageHandler : IHandleMessages<MyMessage>
{
    private readonly MyService service;

    public MyMessageHandler(MyService service)
    {
        this.service = service;
    }

    public Task Handle(MyMessage command, IMessageHandlerContext context)
    {
        return Task.CompletedTask;
    }
}
