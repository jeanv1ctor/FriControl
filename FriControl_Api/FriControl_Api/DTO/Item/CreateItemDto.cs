﻿using FriControl_Api.DTO.Fornecedor;
using FriControl_Api.Enum;
using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;

namespace FriControl_Api.DTO.Item;

public class CreateItemDto
{
    public int Patrimonio { get; set; }
    public string NomeItem { get; set; }
    public string DescricaoItem { get; set; }
    public string MarcaItem { get; set; }
    public ItemEnum ConservacaoItem { get; set; }
    public decimal ValorItem { get; set; }
    public bool Ativo { get; set; }
    public int CategoriaId { get; set; }
    public int? FuncionarioId { get; set; }
    public int? FornecedorId { get; set; }
    
    public CategoriaVinculoDto Categoria { get; set; }
    public FornecedorVinculoDto fornecedor { get; set; }
    
    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now;
}