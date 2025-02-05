using FriControl_Api.Data;
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
    public async Task<ServiceResponse<List<ItemModel>>> CreateItem(ItemModel item)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            if (item == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "As informações do item estão vazias";
                serviceResponse.Sucesso = false;
            }
            
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
    public async Task<ServiceResponse<List<ItemModel>>> UpdateItem(ItemModel itemEditado)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = new ServiceResponse<List<ItemModel>>();

        try
        {
            ItemModel item = _context.Items.AsNoTracking().FirstOrDefault(x => x.Patrimonio == itemEditado.Patrimonio);
            if (item == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum item com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            _context.Items.Update(itemEditado);
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