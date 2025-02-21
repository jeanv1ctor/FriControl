using FriControl_Api.Data;
using FriControl_Api.DTO.Item;
using FriControl_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FriControl_Api.Service;

public class ItemService : IItemInterface
{
    private AppDbContext _context;
    public ItemService(AppDbContext context)
    {
        _context = context;
    }
    
    //implementação do get Item 
    public async Task<ServiceResponse<List<ItemModel>>> GetItem()
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum item encontrado";
            }
            serviceResponse.Dados = _context.Items.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do create Item
    public async Task<ServiceResponse<List<ItemModel>>> CreateItem(CreateItemDto itemDto)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == itemDto.CategoriaId);
            var fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == itemDto.FornecedorId);

            if (categoria == null)
            {
                serviceResponse.Mensagem = "Nenhuma categoria encontrada para cadastrar o item";
            }

            var item = new ItemModel
            {
                Patrimonio = itemDto.Patrimonio,
                NomeItem = itemDto.NomeItem,
                MarcaItem = itemDto.MarcaItem,
                DescricaoItem = itemDto.DescricaoItem,
                ConservacaoItem = itemDto.ConservacaoItem,
                ValorItem = itemDto.ValorItem,
                Ativo = itemDto.Ativo,
                Categoria = categoria,
                Fornecedor = fornecedor,
                DataDeAlteracao = itemDto.DataDeAlteracao,
                DataDeCriacao = itemDto.DataDeCriacao
            };
            
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Items.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do get Item por patrimonio
     public async Task<ServiceResponse<ItemModel>> GetItemByPatrimonio(int patrimonio)
    {
        ServiceResponse<ItemModel> serviceResponse = new ServiceResponse<ItemModel>();

        try
        {
            ItemModel item = _context.Items.FirstOrDefault(x=>x.Patrimonio == patrimonio);

            if (item == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";
                serviceResponse.Sucesso = false;
                
                return serviceResponse;
            }

            serviceResponse.Dados = item;
        }
        catch (Exception e)
        {
          serviceResponse.Mensagem = e.Message;
          serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }
     
    //implementação do update  Item 
    public async Task<ServiceResponse<List<ItemModel>>> UpdateItem(UpdateItemDto itemEditadoDto)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Patrimonio == itemEditadoDto.Patrimonio);
            //var categoria =  _context.Categorias.FirstOrDefault(x => x.Id == itemEditadoDto.CategoriaId);

            if (item == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";    
                serviceResponse.Sucesso = false;           
            }
            
            item.Patrimonio = itemEditadoDto.Patrimonio;
            item.NomeItem = itemEditadoDto.NomeItem;
            item.MarcaItem = itemEditadoDto.MarcaItem;
            item.ConservacaoItem = itemEditadoDto.ConservacaoItem;
            item.ValorItem = itemEditadoDto.ValorItem;
            item.Ativo = itemEditadoDto.Ativo;
            item.DataDeAlteracao = DateTime.Now;
            item.CategoriaId = itemEditadoDto.CategoriaId;
            item.FuncionarioId = itemEditadoDto.FuncionarioId;
            
            
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Items.ToList();
            
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do delete Item 
    public async Task<ServiceResponse<List<ItemModel>>> DeleteItem(int patrimonio)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            ItemModel item = _context.Items.FirstOrDefault(x => x.Patrimonio == patrimonio);
            if (item == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";    
                serviceResponse.Sucesso = false;
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Items.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementaçao do inativa item
    public async Task<ServiceResponse<List<ItemModel>>> InativaItem(int patrimonio)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            ItemModel item = _context.Items.FirstOrDefault(x => x.Patrimonio == patrimonio);

            if (item ==null)
            {   
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }

            item.Ativo = false;
            item.DataDeAlteracao = DateTime.Now;
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Items.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;

    }

    public async Task<ServiceResponse<List<ItemModel>>> TransfereItem(int patrimonio, int idFuncionario)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();
        
        try
        {
            ItemModel item = _context.Items.FirstOrDefault(x => x.Patrimonio == patrimonio);
            var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == idFuncionario);

            if (item ==null)
            {   
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }

            item.FuncionarioId = funcionario.Id;
            item.DataDeAlteracao = DateTime.Now;
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Items.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }
}