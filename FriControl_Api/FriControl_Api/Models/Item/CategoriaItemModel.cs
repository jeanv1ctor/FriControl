using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriControl_Api.Models;

public class CategoriaItemModel
{
    [Key]
    public int Id { get; set; }
    public string NomeCategoria { get; set; }
    [JsonIgnore]
    public List<ItemModel> Items { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
}
