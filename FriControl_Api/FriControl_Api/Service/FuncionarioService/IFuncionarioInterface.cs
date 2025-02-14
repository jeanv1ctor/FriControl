using FriControl_Api.DTO.Funcionario;
using FriControl_Api.Models;

namespace FriControl_Api.Service.FuncionarioService;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
    Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
    Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(CreateFuncionarioDto funcionarioDto);
    Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(UpdateFuncionarioDto funcionarioDto);
    Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
    Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
}