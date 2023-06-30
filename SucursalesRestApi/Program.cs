using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SucursalesRestApi.Models;
using SucursalesRestApi.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // fíjate que el puerta está incluido
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddTransient<ISucursaleRepository, SucursalRepository>();

var app = builder.Build();

app.UseCors("MyAllowedOrigins");

// get the context from the service collection
/*using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<Context>();
    Context.Database.EnsureCreated();
    Context.Seed();
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();