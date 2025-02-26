namespace FriControl_Api.Service.UsuarioService.SenhaService;

public interface ISenhaInterface
{
    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
}