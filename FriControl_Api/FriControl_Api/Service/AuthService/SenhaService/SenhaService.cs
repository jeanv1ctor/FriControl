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
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new [] //definindo as claims
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Cargo.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token); 

    }
}

