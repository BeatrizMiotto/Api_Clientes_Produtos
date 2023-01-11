using Microsoft.AspNetCore.Mvc;
using ApiCliente.Models;
using ApiCliente.ModelViews;

namespace ApiCliente.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var clientes = ClienteRepositorio.Instancia().Lista;
        return StatusCode(200,  clientes);
    }
     [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var cliente = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);

        return StatusCode(200, cliente);
    }
    [HttpPost("")]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        ClienteRepositorio.Instancia().Lista.Add(cliente);
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

       var clienteDb = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);
       if(clienteDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O cliente não existe"
            });
        }

        clienteDb.Nome = cliente.Nome;
        clienteDb.Email = cliente.Email;

        return StatusCode(200, clienteDb);
    }
     [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var clienteDb = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);
        if(clienteDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O cliente não existe"
            });
        }

        ClienteRepositorio.Instancia().Lista.Remove(clienteDb);

        return RedirectToAction(nameof(Index));
    }
    
}