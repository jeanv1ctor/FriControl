using FriControl_Api.DTO.Fornecedor;
using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;
using FriControl_Api.Service;
using FriControl_Api.Service.ForncedorService;
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
    public async Task<ActionResult<ServiceResponse<List<FornecedorModel>>>> CreateFornecedor(CreateFornecedorDto fornecedorDto)
    {
        return Ok(await _fornecedorInterface.CreateFornecedor(fornecedorDto));
    }
    //retorna lista de fornecedor

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<FornecedorModel>>>> GetFornecedor()
    {
        return Ok(await _fornecedorInterface.GetFornecedor());
    }
    
    //retorna fornecedor especifico por id 
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> GetItemByPatrimonio(int id)
    {
        return Ok(await _fornecedorInterface.GetFornecedorById(id));
    }
    //atualiza fornecedor especifico por id 
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> UpdateItem(UpdateFornecedorDto fornecedorDto)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = await _fornecedorInterface.UpdateFornecedor(fornecedorDto);
        return Ok(serviceResponse);
    }
    
    //deleta fornecedor por id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<FornecedorModel>>> DeleteItem(int id)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = await _fornecedorInterface.DeleteFornecedor(id);
        return Ok(serviceResponse);
    }
}