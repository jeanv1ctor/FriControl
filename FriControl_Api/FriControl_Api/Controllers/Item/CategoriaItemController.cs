using FriControl_Api.DTO.Item;
using FriControl_Api.Models;
using FriControl_Api.Service.CategoriaItemService;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaItemController : ControllerBase
{
    private readonly ICategoriaItemInterface _categoriaItemInterface;

    public CategoriaItemController(ICategoriaItemInterface categoriaItemInterface)
    {
        _categoriaItemInterface = categoriaItemInterface;
    }
    
    //cria nova Categoria
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CategoriaItemModel>>>> CreateCategoria(CreateCategoriaDto categoria)
    {
        return Ok(await _categoriaItemInterface.CreateCategoria(categoria));
    }
    
    //retorna lista de categoria
    [HttpGet]
    public async Task<IActionResult> GetCategoria()
    {
        return Ok(await _categoriaItemInterface.GetCategoria());
    }
    
    //retorna categoria especifica por id 
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> GetCategoriaById(int id)
    {
        return Ok(await _categoriaItemInterface.GetCategoriaById(id));
    }
    
    //atualiza categoria especifica por id 
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> UpdateItem(UpdateCategoriaDto categoriaEditado)
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = await _categoriaItemInterface.UpdateCategoria(categoriaEditado);
        return Ok(serviceResponse);
    }
    
    //deleta categoria por id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<CategoriaItemModel>>> DeleteCategoria(int id)
    {
        ServiceResponse<List<CategoriaItemModel>> serviceResponse = await _categoriaItemInterface.DeteleCategoria(id);
        return Ok(serviceResponse);
    }
}