using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using WebAPINET6.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 executed");
//    await next.Invoke();
//    Console.WriteLine("Middleware 1 ends");
//});

//app.Map("/usemapbuilder", builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine("Message from Map Use");
//        await next.Invoke();
//        Console.WriteLine("Message from Map Use Ends");
//    });
//    builder.Run(async context =>
//    {
//        Console.WriteLine("Message from Map Use 2");
//        await context.Response.WriteAsync("From Map Run");
//    });



//});


//app.Run(async context =>
//{
//    Console.WriteLine("Middleware 2 starts");
//    await context.Response.WriteAsync("Hello from Terminal Middleware");
    

//});
app.MapControllers();
app.Run(); // This is important to application to run.
