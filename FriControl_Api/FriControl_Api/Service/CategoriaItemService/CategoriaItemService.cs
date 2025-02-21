using FriControl_Api.Data;
using FriControl_Api.DTO.Item;
using FriControl_Api.Models;

namespace FriControl_Api.Service.CategoriaItemService;

public class CategoriaItemService : ICategoriaItemInterface
{
    private AppDbContext _context;

    public CategoriaItemService(AppDbContext context)
    {
        _context = context;
    }
    
    //implementação do get Categoria
    public async Task<ServiceResponse<List<CategoriaItemModel>>> GetCategoria()
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = new ServiceResponse<List<CategoriaItemModel>>();

        try
        {
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhuma Categoria encontrada.";
            }
            
            serviceResponse.Dados = _context.Categorias.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }
    
    //implementação do Create Categoria
    public async Task<ServiceResponse<List<CategoriaItemModel>>> CreateCategoria(CreateCategoriaDto categoriaDto)
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = new ServiceResponse<List<CategoriaItemModel>>();

        try
        {
            if (categoriaDto == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "As informações da categoria estão vazias";
                serviceResponse.Sucesso = false;
            }

            //instanciando um objeto da categoria model para implementar da DTO da criação de categoria
            var categoria = new CategoriaItemModel
            {
                NomeCategoria = categoriaDto.NomeCategoria,
                DataDeAlteracao = categoriaDto.DataDeAlteracao,
                DataDeCriacao = categoriaDto.DataDeCriacao
            };
            
            
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Categorias.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do get Categoria por id
    public async Task<ServiceResponse<CategoriaItemModel>> GetCategoriaById(int id)
    {
        ServiceResponse<CategoriaItemModel> serviceResponse = new ServiceResponse<CategoriaItemModel>();

        try
        {
            CategoriaItemModel categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhuma categoria com esse registro encontrado";
                serviceResponse.Sucesso = false;
                
            }

            serviceResponse.Dados = categoria;
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    //implementação do update categoria 
    public async Task<ServiceResponse<List<CategoriaItemModel>>> UpdateCategoria(UpdateCategoriaDto categoriaEditado)
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = new ServiceResponse<List<CategoriaItemModel>>();

        try
        {
            CategoriaItemModel categoria = _context.Categorias.FirstOrDefault(x => x.Id == categoriaEditado.Id);
            if (categoria == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhuma categoria com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            categoria.NomeCategoria = categoriaEditado.NomeCategoria;
            categoria.DataDeAlteracao = DateTime.Now;
            
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Categorias.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    //implementação da delete categoria
    public async Task<ServiceResponse<List<CategoriaItemModel>>> DeteleCategoria(int id)
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = new ServiceResponse<List<CategoriaItemModel>>();

        try
        {
            CategoriaItemModel categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhuma categoria com esse registro encontrado";
                serviceResponse.Sucesso = false;             
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Categorias.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }
}