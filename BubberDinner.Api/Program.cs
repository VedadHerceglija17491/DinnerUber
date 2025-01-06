using BubberDinner.Application;
using BubberDinner.Infrastructure;
using BubberDinner.InfraStructure.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    
}   

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

