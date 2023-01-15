using ApiCliente.Models;
using ApiCliente.Repositorios.Interfaces;
using MySql.Data.MySqlClient;

namespace ApiCliente.ModelViews;

public class ProdutoRepositorioMySql : Iprodutos
{
    public ProdutoRepositorioMySql()
    {
        conexaoProduto = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if(conexaoProduto is null) conexaoProduto = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
    }
    private string? conexaoProduto = null;

    private static List<Produto> lista = new List<Produto>();

    public List<Produto> Mostrar()
    {
        var lista = new List<Produto>();
        using(var conex = new MySqlConnection(conexaoProduto))
        {
            conex.Open();
            var query = $"select * from produto;";

            var command = new MySqlCommand(query, conex);
            var dataR = command.ExecuteReader();
            while(dataR.Read())
            {
                lista.Add(new Produto{
                    Id = Convert.ToInt32(dataR["id"]),
                    Nome = dataR["nome"].ToString() ?? "",
                    Descricao = dataR["descricao"].ToString() ?? "",
                    Entrada = dataR["entrada"].ToString() ?? "",
                    Validade = dataR["validade"].ToString() ?? "",
                    Quantidade = Convert.ToInt32(dataR["quantidade"])
                });
            }

            conex.Close();
            
        }
        return lista;
       
    }
    public void Salvar(Produto produto)
    {
        
        using(var conex = new MySqlConnection(conexaoProduto))
        {
            conex.Open();
            var query = $"insert into produto(nome, descricao, entrada, validade, quantidade)values(@nome, @descricao, @entrada, @validade, @quantidade);";

            var command = new MySqlCommand(query, conex);
            //Trabalhar com retorno do Id
            //int id = Convert.ToInt32(command.ExecuteScalar()) ;
            command.Parameters.Add(new MySqlParameter("@Id", produto.Id));
            command.Parameters.Add(new MySqlParameter("@nome", produto.Nome));
            command.Parameters.Add(new MySqlParameter("@descricao", produto.Descricao));
            command.Parameters.Add(new MySqlParameter("@entrada", produto.Entrada));
            command.Parameters.Add(new MySqlParameter("@validade", produto.Validade));
            command.Parameters.Add(new MySqlParameter("@quantidade", produto.Quantidade));
            command.ExecuteNonQuery();

            
            conex.Close();
            
        }
    }
    public Produto Atualizar(Produto produto)
    {
        using(var conex = new MySqlConnection(conexaoProduto))
        {
            conex.Open();
            var query = $"update produto set nome =@nome, descricao=@descricao, entrada=@entrada, validade=@validade, quantidade=@quantidade where id =@id;";

            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", produto.Id));
            command.Parameters.Add(new MySqlParameter("@nome", produto.Nome));
            command.Parameters.Add(new MySqlParameter("@descricao", produto.Descricao));
            command.Parameters.Add(new MySqlParameter("@entrada", produto.Entrada));
            command.Parameters.Add(new MySqlParameter("@validade", produto.Validade));
            command.Parameters.Add(new MySqlParameter("@quantidade", produto.Quantidade));
            command.ExecuteNonQuery();

            conex.Close();
        }
        return produto;  
    }

    public void Apagar(Produto produto)
    {
        using(var conex = new MySqlConnection(conexaoProduto))
        {
            conex.Open();
            var query = $"delete from  produto where id = @id;";
            var command = new MySqlCommand(query, conex);
            command.Parameters.Add(new MySqlParameter("@id", produto.Id));
            command.ExecuteNonQuery();
            conex.Close();    
        }  
    }

}