using FriControl_Api.DTO.SetorFuncionario;
using FriControl_Api.Models;
using FriControl_Api.Service.SetorFuncionarioService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriControl_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SetorFuncionarioController : ControllerBase
{
    private readonly ISetorFuncionarioInterface _setorFuncionarioInterface;

    public SetorFuncionarioController(ISetorFuncionarioInterface setorFuncionarioInterface)
    {
        _setorFuncionarioInterface = setorFuncionarioInterface;
    }

    //cria novo setor
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<List<SetorFuncionarioModel>>>> CreateSetorFuncionario(
        CreateSetorDto setorDto)
    {
        var result = await _setorFuncionarioInterface.CreateSetor(setorDto);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //retorna lista de setores
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<List<SetorFuncionarioModel>>>> GetSetorFuncionario()
    {
        var result = await _setorFuncionarioInterface.GetSetor();
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //retorna setor especifico por id
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> GetSetorFuncionarioById(int id)
    {
        var result = await _setorFuncionarioInterface.GetSetorById(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    
    //atualiza setor especifico por id
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> UpdateSetorFuncionario(UpdateSetorDto setorDto)
    {
        var result = await _setorFuncionarioInterface.UpdateSetor(setorDto);

        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
    //deleta setor por id
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> DeleteSetor(int id)
    {
        var result = await _setorFuncionarioInterface.DeteleSetor(id);
        if (result.Sucesso == false)
        {
            return BadRequest(result.Mensagem);
        }
        return Ok(result);
    }
}