using ProyectoPrueba.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Repositorio.Contrato;
using ProyectoPrueba.Repositorio.implementacion;
using ProyectoPrueba.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});


// para trabajar con modelos genericos
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));

// Cuando sabemos lo q vamos a usar
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
