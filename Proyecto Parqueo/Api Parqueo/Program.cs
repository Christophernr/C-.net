using Microsoft.EntityFrameworkCore;
using mainParqueo;
var builder = WebApplication.CreateBuilder(args); //



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ConexionBD>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

); //configuracion necesaria quellama a la conexion

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

app.MapControllers();
app.Run();
