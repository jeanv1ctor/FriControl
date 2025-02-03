using FriControl_Api.Models;

namespace FriControl_Api.Service.FuncionarioService;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
    Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
    Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel funcionario);
    Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionario);
    Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
    Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
}