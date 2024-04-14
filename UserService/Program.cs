
using UserService.Consumers;
using Microsoft.EntityFrameworkCore;
using Infrastructure.AuthenticationManager;
using Infrastructure.Exceptions;
using Infrastructure.Logging;
using Infrastructure.Services;
using Infrastructure.Config;
using Infrastructure.Behaviors;
using Persistance.Repository;
using UserService.Persistance;
using Asp.Versioning;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddCustomJwtAuthentication(builder.Configuration["Jwt:Secret"], builder.Configuration["Jwt:Issuer"]);
builder.Host.UseSerilogLogger();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingRequestValidator>();
builder.Services.AddDbContext<BookingDbContext>(x =>
{
    x.UseSqlServer(connectionString);
});


builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.ConfigureMassTransit<BookingStatusUpdateConsumer>(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingRequestValidator>();

var app = builder.Build();

app.UseMiddleware<ExceptionLoggingMiddleware>();

app.UseSwagger();

app.UseAuthorization();
app.MapControllers();
app.MapBookingEndpoints();
app.UseSwaggerUI();

app.Run();
