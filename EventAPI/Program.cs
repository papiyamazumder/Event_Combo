using EventBusiness.Services;
using EventData.DataContext;                            // Application level, which the clients/customer access or where the api is created and api brings the user data and decrypts it and then pass it to business and data level
using EventData.REPOSITORY;
using EventEntity;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();          // Install nlog in API and Business Layer only, and declare logger variable in both and define and call it in program.cs

var builder = WebApplication.CreateBuilder(args);       // sets up the application builder, -> used to configure the ASP.NET Core application.

try
{
    // Add services to the container.
    // container - Services
    builder.Services.AddControllers();                     // configures MVC services for the application -> adding essential services for handling HTTP requests and responses using the MVC pattern.  
                                                           // adds the necessary services for MVC to the ASP.NET Core application's dependency injection container, enabling the application to handle HTTP requests using the MVC pattern and providing support for controllers, routing, model binding, and other MVC-related features.

    //add connection string
    //read connection string from appsetting.json file
    string conStr = builder.Configuration.GetConnectionString("sqlCon");
    builder.Services.AddDbContext<EventDbContext>(options => options.UseSqlServer(conStr));

    // Event:
    builder.Services.AddScoped<EventService, EventService>();
    builder.Services.AddScoped<IEventRepository, EventRepository>();    // Injecting the instance of a class to another class to implement loosely coupling. 
                                                                        // The 1st generic parameter IEventRepository specifies the interface type, while the 2nd generic parameter EventRepository specifies the concrete class type that implements the interface.
                                                                        // This registration allows other parts of the application to request an instance of IEventRepository and receive an instance of EventRepository.

    // User:
    builder.Services.AddScoped<UserService, UserService>();
    builder.Services.AddScoped<IUserRepo, UserRepo>();


    // Booking:
    builder.Services.AddScoped<BookingService, BookingService>(); 
    builder.Services.AddScoped<IBookingRepo, BookingRepo>();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();         // It adds services required for API exploration and discovery. Specifically, it enables the generation of metadata about the API endpoints in your application, including route information, HTTP methods, and supported request/response types. This metadata is essential for tools like Swagger to generate accurate API documentation.
    builder.Services.AddCors();                         // Setting up the API for external access, cors => cross origin resource sharing
    builder.Services.AddSwaggerGen();                   // Configures Swagger/OpenAPI documentation generation based on API metadata collected by AddEndpointsApiExplorer().  These documents provide detailed information about your API endpoints, including their paths, request/response formats, parameters, and more.
                                                        // These 2 line above together automatically generate and expose Swagger/OpenAPI documentation for your ASP.NET Core Web API. This documentation serves as a valuable resource for developers who want to understand and consume your API.

    builder.Services.AddLogging(log =>
    {
        log.ClearProviders();
        log.AddNLog();
    });

    var app = builder.Build();      // Instances of class are created using Build()

    // Configure the HTTP request pipeline.
    // Dev, Testing, Producution, QA
    if (app.Environment.IsDevelopment())        // Enviroment: Project status, whether it is Dev/Testing/Production/QA. If devp, then only display swagger otherwise dont display api
    {
        app.UseSwagger();       //Middleware
        app.UseSwaggerUI();     //Middleware
    }

    app.UseCors(x => x.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

    //app.UseAuthentication();   // Login, if user is authenticated, then he/she is authorised to access the projects
    app.UseAuthorization();     //Middleware

    app.MapControllers();       //Middleware to access controllers, i.e. HTTP verbs

    app.Run();                  //Middleware-> connect controller and run the program
}

catch(Exception ex)
{
    logger.Error(ex, "Stopped program");
}

finally
{
    NLog.LogManager.Shutdown();
}