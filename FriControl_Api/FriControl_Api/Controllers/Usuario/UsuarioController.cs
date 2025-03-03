using FriControl_Api.DTO.Usuario;
using FriControl_Api.Service.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers.Usuario;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IAuthInterface _authInterface;

    public UsuarioController(IAuthInterface authInterface)
    {
        _authInterface = authInterface;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> CreateUsuario(CreateUsuarioDto usuarioRegistro)
    {
        var result = await _authInterface.CreateUsuario(usuarioRegistro);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto usuarioLogin)
    {
        var response = await _authInterface.Login(usuarioLogin);
        if (response.Sucesso == false)
        {
            return BadRequest(response.Mensagem);
        }
        return Ok(response);
    }
}