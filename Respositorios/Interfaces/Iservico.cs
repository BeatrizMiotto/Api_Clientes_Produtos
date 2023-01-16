using ApiCliente.Models;

namespace ApiCliente.Repositorios.Interfaces;

public interface Iservico
{
    Task<List<Cliente>> TodosAsync();
    Task SalvarAsync(Cliente cliente);
    Task<Cliente> AtualizarAsync(Cliente cliente);
    Task ApagarAsync(Cliente cliente);
}