using FriControl_Api.Data;
using FriControl_Api.DTO.Usuario;
using FriControl_Api.Models;
using FriControl_Api.Service.UsuarioService.SenhaService;
using Microsoft.EntityFrameworkCore;

namespace FriControl_Api.Service.UsuarioService;

public class AuthService : IAuthInterface
{
    private readonly AppDbContext _context;
    private readonly ISenhaInterface _senhaInterface;
    
    public AuthService(AppDbContext context, ISenhaInterface senhaInterface)
    {
        _context = context;
        _senhaInterface = senhaInterface;
    }
    public async Task<ServiceResponse<List<UsuarioModel>>> CreateUsuario(CreateUsuarioDto usuario)
    {
        ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();
        try
        {
            if (!VerificaEmailExistente(usuario))
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Email ja cadatrado";
                serviceResponse.Sucesso = false;
            }
            
            _senhaInterface.CriarSenhaHash(usuario.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Cargo = usuario.Cargo,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt,
            };
            
            _context.Usuarios.Add(usuarioModel);
            await _context.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;   
    }

    public async Task<ServiceResponse<string>> Login(LoginUsuarioDto usuario)
    {
        ServiceResponse<string> serviceResponse = new ServiceResponse<string>();

        try
        {
            var validaUsuario = await _context.Usuarios.FirstOrDefaultAsync(userBanco => userBanco.Email == usuario.Email);
            if (usuario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuario ou senha invalido";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            //se o retorno da validar senha for false, retorna a mensagem errada.
            if (!_senhaInterface.ValidarSenhaHash(usuario.Senha, validaUsuario.SenhaHash, validaUsuario.SenhaSalt))
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuario ou senha invalido";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            
            var token = _senhaInterface.CriarToken(validaUsuario);
            serviceResponse.Dados = token;
            serviceResponse.Mensagem = "usuario autenticado com sucesso";
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        
        return serviceResponse;
    }


    public bool VerificaEmailExistente(CreateUsuarioDto usuarioRegistro)
    {
        var usuario = _context.Usuarios.FirstOrDefault(userbanco => userbanco.Email == usuarioRegistro.Email);
        if (usuario != null)
        {
            return false; // se o usuario existir, retorna falso
        }
        return true;
    } 
}