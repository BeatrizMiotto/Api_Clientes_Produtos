using Microsoft.AspNetCore.Mvc;
using ApiCliente.Models;
using ApiCliente.ModelViews;
using ApiCliente.Repositorios.Interfaces;

namespace ApiCliente.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{   
    private Iservico _servico;
    public ClientesController(Iservico servico)
    {
        _servico = servico;

    }
    [HttpGet("")]
    public IActionResult Index()
    {
        var clientes = _servico.Todos();
        return StatusCode(200,  clientes);
    }
     [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var cliente = _servico.Todos().Find(c => c.Id == id);

        return StatusCode(200, cliente);
    }
    [HttpPost("")]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        _servico.Salvar(cliente);
        return StatusCode(201, cliente);
    }
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return StatusCode(400, new {
                Mensagem = "Erro"
            });
        }

       var clienteDb = _servico.Atualizar(cliente);
        return StatusCode(200, clienteDb);
    }

     [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var clienteDb = _servico.Todos().Find(c => c.Id == id);
        if(clienteDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O cliente não existe"
            });
        }

        _servico.Apagar(clienteDb);

        return RedirectToAction(nameof(Index));
    }
    
}