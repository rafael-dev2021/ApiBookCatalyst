using APIBookCatalyst.EndPoints;
using APIBookCatalyst.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hellos World!");


app.MapCategoryServiceEndpoints();
app.MapProductServiceEndpoints();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


app.Run();

