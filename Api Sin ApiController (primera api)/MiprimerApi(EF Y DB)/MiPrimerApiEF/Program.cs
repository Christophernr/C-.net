using Microsoft.EntityFrameworkCore;
using MiPrimerApiEF.conexion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<conexionDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //configuro que llame a la conexion 


builder.Services.AddControllers(); //agregamos los controllers que vamos a hacer, los controllers no venian cuando cree la app entonces manualmente lo activo
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers(); //configuro los controllers para que se usen

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
