namespace FriControl_Api.DTO.Item;

public class CreateCategoriaDto
{
    public string NomeCategoria { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
}