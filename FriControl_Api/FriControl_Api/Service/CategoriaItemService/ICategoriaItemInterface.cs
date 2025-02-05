using FriControl_Api.DTO.Item;
using FriControl_Api.Models;

namespace FriControl_Api.Service.CategoriaItemService;

public interface ICategoriaItemInterface
{
    Task<ServiceResponse<List<CategoriaItemModel>>> GetCategoria();
    Task<ServiceResponse<List<CategoriaItemModel>>> CreateCategoria(CreateCategoriaDto categoria);
    Task <ServiceResponse<CategoriaItemModel>> GetCategoriaById(int id);
    Task<ServiceResponse<List<CategoriaItemModel>>> UpdateCategoria(UpdateCategoriaDto categoriaEditado);
    Task<ServiceResponse<List<CategoriaItemModel>>> DeteleCategoria(int id);
}