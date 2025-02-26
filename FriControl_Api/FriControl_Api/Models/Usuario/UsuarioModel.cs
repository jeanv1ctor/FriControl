using System.ComponentModel.DataAnnotations;
using FriControl_Api.Enum;

namespace FriControl_Api.Models;

public class UsuarioModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public CargoEnum Cargo { get; set; }
    public byte[] SenhaHash { get; set; }
    public byte[] SenhaSalt { get; set; }
    public DateTime TokenDataCriacao { get; set; } = DateTime.Now;
}