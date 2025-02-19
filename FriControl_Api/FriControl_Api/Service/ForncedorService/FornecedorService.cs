using FriControl_Api.Data;
using FriControl_Api.DTO.Fornecedor;
using FriControl_Api.Models;
using FriControl_Api.Models.Fornecedor;

namespace FriControl_Api.Service.ForncedorService;

public class FornecedorService : IFornecedorInterface
{
    private AppDbContext _context;

    public FornecedorService(AppDbContext context)
    {
        _context = context;
    }
    
    //implementação do get fornecedor
    public async Task<ServiceResponse<List<FornecedorModel>>> GetFornecedor()
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = new ServiceResponse<List<FornecedorModel>>();
        try
        {
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum fornecedor encontrado";
            }
            serviceResponse.Dados = _context.Fornecedores.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    //implementação do getFornecedorById
    public async Task<ServiceResponse<FornecedorModel>> GetFornecedorById(int id)
    {
        ServiceResponse<FornecedorModel> serviceResponse = new ServiceResponse<FornecedorModel>();

        try
        {
            FornecedorModel fornecedor =  _context.Fornecedores.FirstOrDefault(x => x.Id == id);
            if (fornecedor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum fornecedor encontrado";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Dados = fornecedor;
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    //implementação do create fornecedor
    public async Task<ServiceResponse<List<FornecedorModel>>> CreateFornecedor(CreateFornecedorDto fornecedorDto)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = new ServiceResponse<List<FornecedorModel>>();

        try
        {
            if (fornecedorDto == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "As informações";
            }

            var fornecedor = new FornecedorModel
            {
                NomeEmpresa = fornecedorDto.NomeEmpresa,
                Cnpj =  fornecedorDto.Cnpj,
                Endereco = fornecedorDto.Endereco,
                Observacao = fornecedorDto.Observacao,
                Bairro = fornecedorDto.Bairro,
                Cidade = fornecedorDto.Cidade,
                Uf = fornecedorDto.Uf,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email,
                Ativo = fornecedorDto.Ativo,
                DataDeCriacao = fornecedorDto.DataDeCriacao,
                DataDeAlteracao = fornecedorDto.DataDeAlteracao,
            };

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Fornecedores.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do update fornecedor
    public async Task<ServiceResponse<List<FornecedorModel>>> UpdateFornecedor(UpdateFornecedorDto fornecedorDto)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = new ServiceResponse<List<FornecedorModel>>();

        try
        {
            FornecedorModel fornecedor =  _context.Fornecedores.FirstOrDefault(x => x.Id == fornecedorDto.Id);

            if (fornecedor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum fornecedor com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }

            fornecedor.NomeEmpresa = fornecedorDto.NomeEmpresa;
            fornecedor.Cnpj = fornecedorDto.Cnpj;
            fornecedor.Endereco = fornecedorDto.Endereco;
            fornecedor.Observacao = fornecedorDto.Observacao;
            fornecedor.Bairro = fornecedorDto.Bairro;
            fornecedor.Cidade = fornecedorDto.Cidade;
            fornecedor.Uf = fornecedorDto.Uf;
            fornecedor.Telefone = fornecedorDto.Telefone;
            fornecedor.Email = fornecedorDto.Email;
            fornecedor.Ativo = fornecedorDto.Ativo;
            fornecedor.DataDeCriacao = fornecedorDto.DataDeCriacao;
            fornecedor.DataDeAlteracao = fornecedorDto.DataDeAlteracao;
            
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Fornecedores.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
    
    //implementação do delete fornecedor
    public async Task<ServiceResponse<List<FornecedorModel>>> DeleteFornecedor(int id)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = new ServiceResponse<List<FornecedorModel>>();
        try
        {
            FornecedorModel fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == id);
            if (fornecedor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum fornecedor com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Fornecedores.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    //implementação inativa fornecedor
    public async Task<ServiceResponse<List<FornecedorModel>>> InativaFornecedor(int id)
    {
        ServiceResponse<List<FornecedorModel>> serviceResponse = new ServiceResponse<List<FornecedorModel>>();

        try
        {
            FornecedorModel fornecedor = _context.Fornecedores.FirstOrDefault(x => x.Id == id);
            if (fornecedor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum fornecedor com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            serviceResponse.Dados = _context.Fornecedores.ToList();
            
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }
}