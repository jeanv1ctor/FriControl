namespace FriControl_Api.DTO.SetorFuncionario;

public class SetorVinculoDto
{
    public int Id { get; set; }
    public string NomeSetor { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
}