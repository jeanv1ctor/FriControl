using FriControl_Api.Models;

namespace FriControl_Api.Service.UsuarioService.SenhaService;

public interface ISenhaInterface
{
    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    public bool ValidarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);
    
    public string CriarToken(UsuarioModel usuario);
}