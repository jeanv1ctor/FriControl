using FriControl_Api.DTO.Item;
using FriControl_Api.Models;

namespace FriControl_Api.Service;

public interface IItemInterface
{
    Task<ServiceResponse<List<ItemModel>>> GetItem();
    Task<ServiceResponse<List<ItemModel>>> CreateItem(CreateItemDto item);
    Task <ServiceResponse<ItemModel>> GetItemByPatrimonio(int patrimonio);
    Task<ServiceResponse<List<ItemModel>>> UpdateItem(UpdateItemDto itemEditadoDto);
    Task<ServiceResponse<List<ItemModel>>> DeleteItem(int patrimonio);
    Task<ServiceResponse<List<ItemModel>>> InativaItem(int patrimonio);
}