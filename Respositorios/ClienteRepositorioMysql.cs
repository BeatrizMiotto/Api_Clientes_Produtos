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


    public List<Cliente> Todos()
    {
        var lista = new List<Cliente>();
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"select * from cliente;";

            var command = new MySqlCommand(query, conex);
            var dataR = command.ExecuteReader();
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

    public void Salvar(Cliente cliente)
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
            command.ExecuteNonQuery();

            conex.Close();
            
        }
       
        
    }

    public Cliente Atualizar(Cliente cliente)
    {
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"update cliente set nome =@nome, email=@email where id =@id;";

            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
            command.Parameters.Add(new MySqlParameter("@nome", cliente.Nome));
            command.Parameters.Add(new MySqlParameter("@email", cliente.Email));
            command.ExecuteNonQuery();

            conex.Close();
            
        }
        return cliente;
        
    }

    public void Apagar(Cliente cliente)
    {
        using(var conex = new MySqlConnection(conexao))
        {
            conex.Open();
            var query = $"delete from  cliente where id = @id;";
            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
            command.ExecuteNonQuery();
            conex.Close();    
        }  
    }
}