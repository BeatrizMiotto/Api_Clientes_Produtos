using ApiCliente.Models;

namespace ApiCliente.Repositorios.Interfaces;

public interface Iservico
{
    List<Cliente> Todos();
    void Salvar(Cliente cliente);
    Cliente Atualizar(Cliente cliente);
    void Apagar(Cliente cliente);
}