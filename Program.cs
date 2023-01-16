using ApiCliente.ModelViews;
using ApiCliente.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<Iservico, ClienteRepositorio>();
//builder.Services.AddScoped<Iprodutos, ProdutoRepositorio>();

//builder.Services.AddScoped<Iservico, ClienteRepositorioMysql>();
//builder.Services.AddScoped<Iprodutos, ProdutoRepositorioMySql>();

builder.Services.AddScoped<Iservico, ClienteRepositorioEntity>();
builder.Services.AddScoped<Iprodutos, ProdutoRepositorioEntity>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
