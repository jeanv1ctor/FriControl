using FriControl_Api.DTO.SetorFuncionario;
using FriControl_Api.Models;

namespace FriControl_Api.Service.SetorFuncionarioService;

public interface ISetorFuncionarioInterface
{
    Task<ServiceResponse<List<SetorFuncionarioModel>>> GetSetor();
    Task<ServiceResponse<List<SetorFuncionarioModel>>> CreateSetor(CreateSetorDto setorDto);
    Task <ServiceResponse<SetorFuncionarioModel>> GetSetorById(int id);
    Task<ServiceResponse<List<SetorFuncionarioModel>>> UpdateSetor(UpdateSetorDto categoriaEditado);
    Task<ServiceResponse<List<SetorFuncionarioModel>>> DeteleSetor(int id);
}