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
    public async Task<ActionResult<ServiceResponse<List<CategoriaItemModel>>>> CreateCategoria(CategoriaItemModel categoria)
    {
        return Ok(await _categoriaItemInterface.CreateCategoria(categoria));
    }
    
    //retorna lista de categoria
    [HttpGet]
    public async Task<IActionResult> GetCategoria()
    {
        return Ok(await _categoriaItemInterface.GetCategoria());
    }
}