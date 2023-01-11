namespace ApiCliente.Models;

public record Produto
{
    public int Id {get; set;} = default!;
    public string Nome {get; set;} = default!;
    public string? Descricao {get; set;}
    public string? Entrada {get; set;}
    public string? Validade{get; set;}
    public int Quantidade{get; set;} 
}