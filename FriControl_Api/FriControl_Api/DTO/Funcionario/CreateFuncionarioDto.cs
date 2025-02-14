using FriControl_Api.DTO.SetorFuncionario;

namespace FriControl_Api.DTO.Funcionario;

public class CreateFuncionarioDto
{

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Uf { get; set; }
    public int SetorId { get; set; }
    public SetorVinculoDto Setor { get; set; }
    public bool Ativo { get; set; }

    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
}