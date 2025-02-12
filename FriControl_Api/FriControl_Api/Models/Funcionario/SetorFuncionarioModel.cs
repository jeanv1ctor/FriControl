using System.ComponentModel.DataAnnotations;

namespace FriControl_Api.Models;

public class SetorFuncionarioModel
{
    [Key]
    public int Id { get; set; }
    public string NomeSetor { get; set; }
    public List<FuncionarioModel> Funcionarios { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
}
