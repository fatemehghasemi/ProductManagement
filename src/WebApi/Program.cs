using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Product Management API",
    Version = "v1",
    Description = "A comprehensive API for managing products, materials, sizes, and related entities using Clean Architecture with CQRS pattern",
    Contact = new OpenApiContact
    {
      Name = "Product Management Team",
      Email = "support@productmanagement.com"
    }
  });

  c.TagActionsBy(api => new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] });
  c.DocInclusionPredicate((name, api) => true);
});

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", policy =>
  {
    policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
  });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API V1");
  c.RoutePrefix = string.Empty;
  c.DisplayRequestDuration();
  c.EnableTryItOutByDefault();
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
