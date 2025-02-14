namespace FriControl_Api.DTO.Funcionario;

public class UpdateFuncionarioDto
{
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

    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
}