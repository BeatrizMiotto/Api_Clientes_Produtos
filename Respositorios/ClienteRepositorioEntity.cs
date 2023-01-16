using ApiCliente.Models;
using ApiCliente.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApiCliente.Contexto;

namespace ApiCliente.ModelViews;

/*public class ClienteContexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if(conexao is null) conexao = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

    }
    public DbSet<Cliente> Cliente {get; set;} = default!;

}*/
public class ClienteRepositorioEntity : Iservico
{
    private ClienteContexto contexto;
    public ClienteRepositorioEntity()
    {
        contexto = new ClienteContexto();
    }
    private string? conexao = null;


    public List<Cliente> Todos()
    {
        
        return contexto.Cliente.ToList();
       
    }

    public void Salvar(Cliente cliente)
    {  
        contexto.Cliente.Add(cliente);
        contexto.SaveChanges(); 
    }

    public Cliente Atualizar(Cliente cliente)
    {
        contexto.Entry(cliente).State = EntityState.Modified;
        
        contexto.SaveChanges();

        return cliente;
        
    }

    public void Apagar(Cliente cliente)
    {
        var excluir = contexto.Cliente.Find(cliente.Id);
        if(excluir is null) throw new Exception("Cliente não localizado.");
        contexto.Cliente.Remove(excluir);
        contexto.SaveChanges();
        
    }
}