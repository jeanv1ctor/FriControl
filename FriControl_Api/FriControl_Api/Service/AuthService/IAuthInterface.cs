using FriControl_Api.DTO.Usuario;
using FriControl_Api.Models;

namespace FriControl_Api.Service.UsuarioService;

public interface IAuthInterface
{
    Task<ServiceResponse<List<UsuarioModel>>> RegistraUsuario(CreateUsuarioDto usuario);
}
