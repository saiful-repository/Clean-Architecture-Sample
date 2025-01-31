using Asp.Versioning;
using CleanArchitectureSample.Application;
using CleanArchitectureSample.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API v1", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "API v2", Version = "v2" });
});

builder.Services
        .AddApplication()
       .AddInfrastructure(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{   
    options.AssumeDefaultVersionWhenUnspecified = true;

    options.DefaultApiVersion = ApiVersion.Default;
    
    options.ReportApiVersions = true;

    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader(),
        new MediaTypeApiVersionReader()
        );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {

        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
    });
}

app.MapControllers();
app.Run();

