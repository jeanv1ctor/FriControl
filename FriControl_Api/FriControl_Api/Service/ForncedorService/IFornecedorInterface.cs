using FriControl_Api.DTO.Fornecedor;
using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;

namespace FriControl_Api.Service.ForncedorService;

public interface IFornecedorInterface
{
    Task<ServiceResponse<List<FornecedorModel>>> GetFornecedor();
    Task<ServiceResponse<FornecedorModel>> GetFornecedorById(int id);
    Task<ServiceResponse<List<FornecedorModel>>> CreateFornecedor(CreateFornecedorDto fornecedorDto);
    Task<ServiceResponse<List<FornecedorModel>>> UpdateFornecedor(UpdateFornecedorDto fornecedorDto);
    Task<ServiceResponse<List<FornecedorModel>>> DeleteFornecedor(int id);
    Task<ServiceResponse<List<FornecedorModel>>> InativaFornecedor(int id);
}