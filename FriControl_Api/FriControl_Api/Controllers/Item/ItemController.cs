using FriControl_Api.Models;
using FriControl_Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemInterface _itemInterface;

    public ItemController(IItemInterface itemInterface)
    {
        _itemInterface = itemInterface;        
    }
    
    //cria novo item
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> CreateItem(ItemModel item)
    {
        return Ok(await _itemInterface.CreateItem(item));
    }
    
    //retorna lista de item
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetItem()
    {
        return Ok(await _itemInterface.GetItem());
    }
    
    //retorna item especifico por patrimonio 
    [HttpGet("{patrimonio}")]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> GetItemByPatrimonio(int patrimonio)
    {
        return Ok(await _itemInterface.GetItemByPatrimonio(patrimonio));
    }
    
    //atualiza item especifico por patrimonio 
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> UpdateItem(ItemModel itemEditado)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = await _itemInterface.UpdateItem(itemEditado);
        return Ok(serviceResponse);
    }
    
    //deleta item por patrimonio
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> DeleteItem(int patrimonio)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = await _itemInterface.DeleteItem(patrimonio);
        return Ok(serviceResponse);
    }
    
    //inativa item especifico por patrimonio 
    [HttpPut("inativa item")]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> InativaItem(int patrimonio)
    {
        ServiceResponse<List<ItemModel>> serviceResponse = await _itemInterface.InativaItem(patrimonio);
        return Ok(serviceResponse);
    }
    

}