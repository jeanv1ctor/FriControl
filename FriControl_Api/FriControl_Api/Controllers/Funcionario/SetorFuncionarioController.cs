using FriControl_Api.DTO.SetorFuncionario;
using FriControl_Api.Models;
using FriControl_Api.Service.SetorFuncionarioService;
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
    public async Task<ActionResult<ServiceResponse<List<SetorFuncionarioModel>>>> CreateSetorFuncionario(
        CreateSetorDto setorDto)
    {
        return Ok(await _setorFuncionarioInterface.CreateSetor(setorDto));
    }
    
    //retorna lista de setores
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<SetorFuncionarioModel>>>> GetSetorFuncionario()
    {
        return Ok(await _setorFuncionarioInterface.GetSetor());
    }
    
    //retorna setor especifico por id
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> GetSetorFuncionarioById(int id)
    {
        return Ok(await _setorFuncionarioInterface.GetSetorById(id));
    }
    
    //atualiza setor especifico por id
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> UpdateSetorFuncionario(UpdateSetorDto setorDto)
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse =
            await _setorFuncionarioInterface.UpdateSetor(setorDto);
        return Ok(serviceResponse);
    }
    //deleta setor por id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<SetorFuncionarioModel>>> DeleteSetor(int id)
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse = await _setorFuncionarioInterface.DeteleSetor(id);
        return Ok(serviceResponse);
    }
}