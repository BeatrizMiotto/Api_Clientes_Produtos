using ApiCliente.Contexto;
using Microsoft.EntityFrameworkCore;
using ApiCliente.Repositorios.Interfaces;
using ApiCliente.Models;

namespace ApiCliente.ModelViews;

public class ProdutoRepositorioEntity : Iprodutos
{
    private ProdutoContexto contexto;
    public ProdutoRepositorioEntity()
    {
        contexto = new ProdutoContexto();
    }
    private string? conexao = null;

    public List<Produto> Mostrar()
    {
        
        return contexto.Produto.ToList();
       
    }
    public void Salvar(Produto produto)
    {  
        contexto.Produto.Add(produto);
        contexto.SaveChanges(); 
    }

    public Produto Atualizar(Produto produto)
    {
        contexto.Entry(produto).State = EntityState.Modified;
        
        contexto.SaveChanges();

        return produto;
        
    }

    public void Apagar(Produto produto)
    {
        var excluir = contexto.Produto.Find(produto.Id);
        if(excluir is null) throw new Exception("Cliente não localizado.");
        contexto.Produto.Remove(excluir);
        contexto.SaveChanges();
        
    }
}