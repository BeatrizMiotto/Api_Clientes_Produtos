using ApiCliente.Models;
using ApiCliente.Repositorios.Interfaces;

namespace ApiCliente.ModelViews;

public class ProdutoRepositorio : Iprodutos
{
    
    public static  List<Produto> listaProduto = new List<Produto>();

    public List<Produto> Mostrar()
    {
        return listaProduto;
    }

    public void Salvar(Produto produto)
    {
        listaProduto.Add(produto);
    }

    public Produto Atualizar(Produto produto)
    {
        if(produto.Id == 0) throw new Exception("Id não pode ser zero");

        var produtoDb = listaProduto.Find(c => c.Id == produto.Id);
        if(produtoDb is null)
        {
            throw new Exception("O produto não existe");
        }

        produtoDb.Nome = produto.Nome;
        produtoDb.Descricao = produto.Descricao;
        produtoDb.Entrada = produto.Entrada;
        produtoDb.Validade = produto.Validade;
        produtoDb.Quantidade = produto.Quantidade;
        return produtoDb;
    }

    public void Apagar(Produto produto)
    {
        listaProduto.Remove(produto);
    }

    
}