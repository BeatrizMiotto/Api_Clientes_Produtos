using ApiCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Contexto;

public class ClienteContexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if(conexao is null) conexao = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

    }
    public DbSet<Cliente> Cliente {get; set;} = default!;

}