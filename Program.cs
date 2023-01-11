using ApiCliente.ModelViews;
using ApiCliente.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

ClienteRepositorio.Instancia().Lista.Add(new Cliente {Id = 1, Nome = "Jasmine", Email = "jas@gmail.com"});
ClienteRepositorio.Instancia().Lista.Add(new Cliente {Id = 2, Nome = "Eduardo", Email = "dudu@gmail.com"});

ProdutoRepositorio.Instancia().ListaProduto.Add(new Produto {Id= 1, Nome = "Uva", Descricao = "Uva verde", Entrada = "11/01/2023", Validade = "15/01/2023", Quantidade = 10});
ProdutoRepositorio.Instancia().ListaProduto.Add(new Produto {Id= 2, Nome = "Banana", Descricao = "Banana nanica", Entrada = "11/01/2023", Validade = "18/01/2023", Quantidade = 20});

app.Run();
