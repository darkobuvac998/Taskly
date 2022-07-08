using System.Reflection;
using System.Text.Json.Serialization;
using TasklyAPI.Extensions;
using TasklyAPI.TasklyMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(TasklyMappings));
builder.Services.AddDatabaseConnection(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
});

app.MapControllers();

app.Run();
