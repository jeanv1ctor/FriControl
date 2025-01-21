using System.ComponentModel.DataAnnotations;

namespace FriControl_Api.Models;

public class ItemModel
{
    [Key]
    public int Patrimonio { get; set; }
    public string NomeItem { get; set; }
    public string? ObservacoesItem { get; set; }
    public string ModeloItem { get; set; }
    
    public FuncionarioModel Funcionario { get; set; }
    public CategoriaItemModel Categoria { get; set; }
}