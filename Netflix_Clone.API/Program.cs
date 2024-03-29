using Netflix_Clone.API.Extensions.API;
using Netflix_Clone.API.Extensions.Application;
using Netflix_Clone.API.Extensions.Domain;
using Netflix_Clone.API.Extensions.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterDomainServices();
builder.RegisterAPIServices();
builder.RegisterApplicationServices();
builder.RegisterInfrastructureServices();

// i have convert the order of registering the services [App-Infra]

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
//}

if (app.Environment.IsProduction())
{
    app.UseStatusCodePages();
    app.UseExceptionHandler();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
