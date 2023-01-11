using ApiCliente.ModelViews;
using  Microsoft.AspNetCore.Mvc;
namespace ApiCliente.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [Route("/")]
    [HttpGet]
    public ActionResult Index()
    {
        return StatusCode(200, new Home{
            Mensagem = "Olá! Essa é minha Api de Clientes e Produtos!!!"
        });
    }
    
}