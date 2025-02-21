using FriControl_Api.DTO.Item;
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
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> CreateItem(CreateItemDto itemDto)
    {
        var result = await _itemInterface.CreateItem(itemDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
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
        var result = await _itemInterface.GetItemByPatrimonio(patrimonio);
        if (result.Sucesso == false)
        {
            return NotFound(result);
        }
        return Ok(await _itemInterface.GetItemByPatrimonio(patrimonio));
    }
    
    //atualiza item especifico por patrimonio 
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> UpdateItem(UpdateItemDto itemEditadoDto)
    {
        var result = await _itemInterface.UpdateItem(itemEditadoDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //deleta item por patrimonio
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> DeleteItem(int patrimonio)
    {
        var result = await _itemInterface.DeleteItem(patrimonio);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        
        return Ok(result);
    }
    
    //inativa item especifico por patrimonio 
    [HttpPut("inativa_item")]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> InativaItem(int patrimonio)
    {
        var result = await _itemInterface.InativaItem(patrimonio);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //transfere item para outro funcionário

    [HttpPut("transfere_item")]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> TransfereItem(int patrimonio, int funcionarioId)
    {
        var result = await _itemInterface.TransfereItem(patrimonio, funcionarioId);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        
        return Ok(result);
    }

}