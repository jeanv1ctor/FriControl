using FriControl_Api.Models;

namespace FriControl_Api.Service.CategoriaItemService;

public interface ICategoriaItemInterface
{
    Task<ServiceResponse<List<CategoriaItemModel>>> GetCategoria();
    Task<ServiceResponse<List<CategoriaItemModel>>> CreateCategoria(CategoriaItemModel categoria);
    Task <ServiceResponse<CategoriaItemModel>> GetCategoriaById(int id);
    Task<ServiceResponse<List<CategoriaItemModel>>> UpdateCategoria(CategoriaItemModel categoriaEditado);
    Task<ServiceResponse<List<CategoriaItemModel>>> DeteleCategoria(int id);
}