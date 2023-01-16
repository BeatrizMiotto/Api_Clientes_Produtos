namespace ApiCliente.DTOs;

public record ClienteDTO
{
    public string Nome {get; set;} = default!;
    public string? Email {get; set;}
}