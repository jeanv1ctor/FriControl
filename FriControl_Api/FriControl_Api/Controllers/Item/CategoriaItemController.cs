﻿using FriControl_Api.DTO.Item;
using FriControl_Api.Models;
using FriControl_Api.Service.CategoriaItemService;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult<ServiceResponse<List<CategoriaItemModel>>>> CreateCategoria(CreateCategoriaDto categoria)
    {
        var result = await _categoriaItemInterface.CreateCategoria(categoria);
        
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //retorna lista de categoria
    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> GetCategoria()
    {
        var result = await _categoriaItemInterface.GetCategoria();
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        
        return Ok(result);
    }
    
    //retorna categoria especifica por id 
    [HttpGet("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> GetCategoriaById(int id)
    {
        var result = await _categoriaItemInterface.GetCategoriaById(id);
        
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //atualiza categoria especifica por id 
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> UpdateItem(UpdateCategoriaDto categoriaEditado)
    {
        var result = await _categoriaItemInterface.UpdateCategoria(categoriaEditado);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //deleta categoria por id
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<CategoriaItemModel>>> DeleteCategoria(int id)
    {
        var result = await _categoriaItemInterface.DeteleCategoria(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }

        return Ok(result);
    }
}