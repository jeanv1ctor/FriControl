using System.ComponentModel.DataAnnotations;


namespace FriControl_Api.Models;

public class FuncionarioModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Uf { get; set; }
    public int SetorId { get; set; }
    public bool Ativo { get; set; }
    public List<ItemModel>? Items { get; set; }
    public SetorFuncionario Setor { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
    
}