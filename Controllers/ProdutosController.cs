using ApiCliente.Models;
using ApiCliente.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers;

[Route("produtos")]
public class ProdutosController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var produtos = ProdutoRepositorio.Instancia().ListaProduto;
        return StatusCode(200,  produtos);
    }
    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var produto = ProdutoRepositorio.Instancia().ListaProduto.Find(c => c.Id == id);

        return StatusCode(200, produto);
    }
    [HttpPost("")]
    public IActionResult Create([FromBody] Produto produto)
    {
        ProdutoRepositorio.Instancia().ListaProduto.Add(produto);
        return StatusCode(201, produto);
    }
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Produto produto)
    {
        if (id != produto.Id)
        {
            return StatusCode(400, new {
                Mensagem = "Erro"
            });
        }

       var produtoDb = ProdutoRepositorio.Instancia().ListaProduto.Find(c => c.Id == id);
       if(produtoDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O produto não existe"
            });
        }

        produtoDb.Nome = produto.Nome;
        produtoDb.Descricao = produto.Descricao;
        produtoDb.Entrada = produto.Entrada;
        produtoDb.Validade = produto.Validade;
        produtoDb.Quantidade = produto.Quantidade;
        

        return StatusCode(200, produtoDb);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var produtoDb = ProdutoRepositorio.Instancia().ListaProduto.Find(c => c.Id == id);
        if(produtoDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O produto não existe"
            });
        }

        ProdutoRepositorio.Instancia().ListaProduto.Remove(produtoDb);

        return RedirectToAction(nameof(Index));
    }
    
}