using System.ComponentModel.DataAnnotations;
using FriControl_Api.Enum;

namespace FriControl_Api.DTO.Usuario;

public class CreateUsuarioDto
{
    
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public CargoEnum Cargo { get; set; }
    public string Senha { get; set; }
    [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
    public string ConfirmacaoSenha { get; set; }
}