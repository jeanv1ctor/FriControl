

using FriControl_Api.Models;
using FriControl_Api.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioInterface _funcionarioInterface;

    public FuncionarioController(IFuncionarioInterface funcionarioInterface)
    {
        _funcionarioInterface = funcionarioInterface;
    }
    
    //cria novo funcionario

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> CreateFuncionario(FuncionarioModel funcionario)
    {
        return Ok(await _funcionarioInterface.CreateFuncionario(funcionario));
    }
    
    //retorna lista de funcionarios
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetFuncionario()
    {
        return Ok(await _funcionarioInterface.GetFuncionario());
    }
    
    //retorna funcionario especifico por id
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetFuncionarioById(int id)
    {
        return Ok(await _funcionarioInterface.GetFuncionarioById(id));
    }
    
    //atualiza funcionario especifico por id

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> UpdateFuncionario(FuncionarioModel funcionarioEditado)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(funcionarioEditado);
        return Ok(serviceResponse);
    }
    
    //deleta item por id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> DeleteFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);
        return Ok(serviceResponse);
    }
    
    //inativa funcionario especifico por id 
    [HttpPut("inativa funcionario")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);
        return Ok(serviceResponse);
    }
}