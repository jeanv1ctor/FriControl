﻿using FriControl_Api.Models;

namespace FriControl_Api.Service;

public interface IItemInterface
{
    Task<ServiceResponse<List<ItemModel>>> GetItem();
    Task<ServiceResponse<List<ItemModel>>> CreateItem(ItemModel item);
    Task <ServiceResponse<ItemModel>> GetItemByPatrimonio(int patrimonio);
    Task<ServiceResponse<List<ItemModel>>> UpdateItem(ItemModel itemEditado);
    Task<ServiceResponse<List<ItemModel>>> DeleteItem(int patrimonio);
    Task<ServiceResponse<List<ItemModel>>> InativaItem(int patrimonio);
}