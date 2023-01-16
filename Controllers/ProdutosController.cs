using ApiCliente.Models;
using ApiCliente.ModelViews;
using Microsoft.AspNetCore.Mvc;
using ApiCliente.Repositorios.Interfaces;

namespace ApiCliente.Controllers;

[Route("produtos")]
public class ProdutosController : ControllerBase
{
    private Iprodutos _produto;
    public ProdutosController(Iprodutos produto)
    {
       _produto = produto;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var produtos =_produto.Mostrar();
        return StatusCode(200,  produtos);
    }
    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var produto =_produto.Mostrar().Find(c => c.Id == id);

        return StatusCode(200, produto);
    }
    [HttpPost("")]
    public IActionResult Create([FromBody] Produto produto)
    {
       _produto.Salvar(produto);
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

       var produtoDb =_produto.Atualizar(produto);
        return StatusCode(200, produtoDb);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var produtoDb =_produto.Mostrar().Find(c => c.Id == id);
        if(produtoDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O produto não existe"
            });
        }

       _produto.Apagar(produtoDb);

        return StatusCode(204);
    }
    
}