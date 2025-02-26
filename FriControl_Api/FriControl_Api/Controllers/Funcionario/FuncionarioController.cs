

using FriControl_Api.DTO.Funcionario;
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
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> CreateFuncionario(CreateFuncionarioDto funcionarioDto)
    {
        var result = await _funcionarioInterface.CreateFuncionario(funcionarioDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        
        return Ok(result);
    }
    
    //retorna lista de funcionarios
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetFuncionario()
    {
        var result = await _funcionarioInterface.GetFuncionario();
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        
        return Ok(result);
    }
    
    //retorna funcionario especifico por id
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> GetFuncionarioById(int id)
    {
        var result = await _funcionarioInterface.GetFuncionarioById(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //atualiza funcionario especifico por id

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<ItemModel>>>> UpdateFuncionario(UpdateFuncionarioDto funcionarioDto)
    {
        var result = await _funcionarioInterface.UpdateFuncionario(funcionarioDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //deleta funcionario por id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<ItemModel>>> DeleteFuncionario(int id)
    {
        var result = await _funcionarioInterface.DeleteFuncionario(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //inativa funcionario especifico por id 
    [HttpPut("inativa_funcionario")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> InativaFuncionario(int id)
    {
        var result = await _funcionarioInterface.InativaFuncionario(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
}