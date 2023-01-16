using ApiCliente.Models;
using ApiCliente.Repositorios.Interfaces;
using MySql.Data.MySqlClient;

namespace ApiCliente.ModelViews;

public class ClienteRepositorioMysql : Iservico
{
    public ClienteRepositorioMysql()
    {
        conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if(conexao is null) conexao = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
    }
    private string? conexao = null;

     private static List<Cliente> lista = new List<Cliente>();


    public async Task<List<Cliente>> TodosAsync()
    {
        var lista = new List<Cliente>();
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"select * from cliente;";

            var command = new MySqlCommand(query, conex);
            var dataR = await command.ExecuteReaderAsync();
            while(dataR.Read())
            {
                lista.Add(new Cliente{
                    Id = Convert.ToInt32(dataR["id"]),
                    Nome = dataR["nome"].ToString() ?? "",
                    Email = dataR["email"].ToString() ?? ""
                });
            }

            conex.Close();
            
        }
        return lista;
       
    }

    public async Task SalvarAsync(Cliente cliente)
    {
        
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"insert into cliente(nome, email)values(@nome, @email);";

            var command = new MySqlCommand(query, conex);
            //Trabalhar com retorno do Id
            //int id = Convert.ToInt32(command.ExecuteScalar()) ;
            command.Parameters.Add(new MySqlParameter("@nome", cliente.Nome));
            command.Parameters.Add(new MySqlParameter("@email", cliente.Email));
            await command.ExecuteNonQueryAsync();

            conex.Close();
            
        }
       
        
    }

    public async Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"update cliente set nome =@nome, email=@email where id =@id;";

            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
            command.Parameters.Add(new MySqlParameter("@nome", cliente.Nome));
            command.Parameters.Add(new MySqlParameter("@email", cliente.Email));
            await command.ExecuteNonQueryAsync();

            conex.Close();
            
        }
        return cliente;
        
    }

    public async Task ApagarAsync(Cliente cliente)
    {
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"delete from  cliente where id = @id;";
            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
            await command.ExecuteNonQueryAsync();
            conex.Close();    
        }  
    }
}