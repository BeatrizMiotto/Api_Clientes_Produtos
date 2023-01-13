using ApiCliente.Models;

namespace ApiCliente.Repositorios.Interfaces;

public interface Iprodutos
{
    List<Produto> Mostrar();
    void Salvar(Produto produto);
    Produto Atualizar(Produto produto);
    void Apagar(Produto produto);
}