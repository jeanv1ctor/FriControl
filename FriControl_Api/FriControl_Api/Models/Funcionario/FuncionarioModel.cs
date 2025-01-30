using System.ComponentModel.DataAnnotations;


namespace FriControl_Api.Models;

public class FuncionarioModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Ativo { get; set; }
    //public List<ItemModel>? Items { get; set; }
    public SetorFuncionario Setor { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    
}