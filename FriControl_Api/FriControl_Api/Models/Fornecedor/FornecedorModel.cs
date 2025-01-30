using System.ComponentModel.DataAnnotations;

namespace FriControl_Api.Models.Fornecedor;

public class FornecedorModel
{
    [Key]
    public int Id { get; set; }
    public string NomeEmpresa { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Observacao { get; set; }
    public string Uf { get; set; }
    public string Cnpj { get; set; }
    public bool Ativo { get; set; }
    public List<ItemModel>? Items { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
}