using ApiCliente.Models;

namespace ApiCliente.ModelViews;

public class ClienteRepositorioMysql
{
    private ClienteRepositorioMysql()
    {
        Lista = new List<Cliente>();
    }
    public  List<Cliente> Lista = default!;

    private static ClienteRepositorioMysql? clienteRepositorioMysql;

    public static ClienteRepositorioMysql Instancia()
    {
        if(clienteRepositorioMysql is null) clienteRepositorioMysql = new ClienteRepositorioMysql();
        return clienteRepositorioMysql;
    }
    
}