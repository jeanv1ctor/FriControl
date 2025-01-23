using FriControl_Api.Models;
using FriControl_Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemInterface _itemService;

    public ItemController(IItemInterface itemService)
    {
        _itemService = itemService;        
    }
    //retorna lista de item
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetItem()
    {
        return Ok(await _itemService.GetItem());
    }
    
    //cria novo item
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> CreateItem(ItemModel item)
    {
        return Ok(await _itemService.CreateItem(item));
    }
}