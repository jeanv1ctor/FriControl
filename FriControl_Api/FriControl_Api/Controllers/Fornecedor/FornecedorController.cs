using FriControl_Api.DTO.Fornecedor;
using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;
using FriControl_Api.Service;
using FriControl_Api.Service.ForncedorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers.Fornecedor;

[Route("api/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase 
{
    private readonly IFornecedorInterface _fornecedorInterface;

    public FornecedorController(IFornecedorInterface fornecedorInterface)
    {
        _fornecedorInterface = fornecedorInterface;
    }
    
    //cria novo fornecedor
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<List<FornecedorModel>>>> CreateFornecedor(CreateFornecedorDto fornecedorDto)
    {
        var result = await _fornecedorInterface.CreateFornecedor(fornecedorDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    //retorna lista de fornecedor

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<List<FornecedorModel>>>> GetFornecedor()
    {
        var result = await _fornecedorInterface.GetFornecedor();
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //retorna fornecedor especifico por id 
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> GetItemByPatrimonio(int id)
    {
        var result = await _fornecedorInterface.GetFornecedorById(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    //atualiza fornecedor especifico por id 
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> UpdateItem(UpdateFornecedorDto fornecedorDto)
    {
        var result = await _fornecedorInterface.UpdateFornecedor(fornecedorDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //deleta fornecedor por id
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> DeleteItem(int id)
    {
        var result = await _fornecedorInterface.DeleteFornecedor(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
}