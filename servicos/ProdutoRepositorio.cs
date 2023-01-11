using ApiCliente.Models;

namespace ApiCliente.ModelViews;

public class ProdutoRepositorio
{
    private ProdutoRepositorio()
    {
        ListaProduto = new List<Produto>();
    }
    public  List<Produto> ListaProduto = default!;

    private static ProdutoRepositorio? produtoRepositorio;

    public static ProdutoRepositorio Instancia()
    {
        if(produtoRepositorio is null) produtoRepositorio = new ProdutoRepositorio();
        return produtoRepositorio;
    }
}