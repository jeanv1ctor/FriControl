using FriControl_Api.Data;
using FriControl_Api.Models;

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
            serviceResponse.Dados = _context.Items.ToList();
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum item encontrado";
            }
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
                serviceResponse.Mensagem = "informar dados do item";
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

    public Task<ServiceResponse<List<ItemModel>>> GetItemByPatrimonio(int patrimonio)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<ItemModel>>> UpdateItem(ItemModel item)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<ItemModel>>> DeleteItem(int patrimonio)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<ItemModel>>> InativaItem(int patrimonio)
    {
        throw new NotImplementedException();
    }
}