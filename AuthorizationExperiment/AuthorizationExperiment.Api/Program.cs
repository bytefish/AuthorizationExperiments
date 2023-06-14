using AuthorizationExperiment.Api.Base.Connections;
using AuthorizationExperiment.Api.Services.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddSingleton<ISqlConnectionFactory>(services =>
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationDatabase");

    if (string.IsNullOrWhiteSpace(connectionString))
    {
        throw new InvalidOperationException("No ConnectionString for 'ApplicationDatabase' found");
    }

    return new SqlServerConnectionFactory(connectionString);
});

builder.Services.AddSingleton<TaskManager>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
