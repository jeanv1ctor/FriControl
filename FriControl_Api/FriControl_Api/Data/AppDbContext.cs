using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;
using Microsoft.EntityFrameworkCore;

namespace FriControl_Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); 
    }
    
    public DbSet<FuncionarioModel> Funcionarios { get; set; }
    public DbSet<SetorFuncionarioModel> SetorFuncionarios { get; set; }    
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<CategoriaItemModel> Categorias { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<FornecedorModel> Fornecedores { get; set; }
}