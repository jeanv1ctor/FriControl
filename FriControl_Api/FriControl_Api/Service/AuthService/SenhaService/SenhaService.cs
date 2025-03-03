using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FriControl_Api.Models;
using FriControl_Api.Service.UsuarioService.SenhaService;
using Microsoft.IdentityModel.Tokens;


namespace FriControl_Api.Service.AuthService.SenhaService;

public class SenhaService : ISenhaInterface
{
    private ISenhaInterface _senhaInterfaceImplementation;
    private readonly IConfiguration _config;

    public SenhaService(IConfiguration config)
    {
        _config = config;
    }

    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }
    }
    
    
    public bool ValidarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt))
        {
            var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return computerHash.SequenceEqual(senhaHash);
        }
    }

    public string CriarToken(UsuarioModel usuario)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("Cargo", usuario.Cargo.ToString()),
            new Claim("Email", usuario.Email),
        };
        //puxa o token pre definido no appsettings
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
        
        //gera credencial
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        //cria as informações do token
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credenciais
        );
        //cria o token completo
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}

