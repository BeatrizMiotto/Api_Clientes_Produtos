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


    public async Task<List<Cliente>> TodosAsync()
    {
        
        return await contexto.Cliente.ToListAsync();
       
    }

    public async Task SalvarAsync(Cliente cliente)
    {  
        contexto.Cliente.Add(cliente);
        await contexto.SaveChangesAsync(); 
    }

    public async Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        contexto.Entry(cliente).State = EntityState.Modified;
        
        await contexto.SaveChangesAsync();

        return cliente;
        
    }

    public async Task ApagarAsync(Cliente cliente)
    {
        var excluir = await contexto.Cliente.FindAsync(cliente.Id);
        if(excluir is null) throw new Exception("Cliente não localizado.");
        contexto.Cliente.Remove(excluir);
        await contexto.SaveChangesAsync();
        
    }
}