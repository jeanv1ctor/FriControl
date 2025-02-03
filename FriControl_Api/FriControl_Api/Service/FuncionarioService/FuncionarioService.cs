using FriControl_Api.Data;
using FriControl_Api.Models;

namespace FriControl_Api.Service.FuncionarioService;

public class FuncionarioService : IFuncionarioInterface
{
    private AppDbContext _context;

    public FuncionarioService(AppDbContext context)
    {
        _context = context;
    }
    
    //implementação do get funcionario

    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            serviceResponse.Dados = _context.Funcionarios.ToList();
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum funcionario encontrado";   
            }
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

        try
        {
            FuncionarioModel funcionarioModel = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            if (id == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum funcionario com esse registro encontrado";
            }
            serviceResponse.Dados = funcionarioModel;
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    //implementação do Create Funcionario
    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel funcionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum funcionario com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Funcionarios.ToList();
        }
        catch (Exception e)
        {

            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;   
        }
        
        return serviceResponse;
    }

    //implementação do update funcionario
    public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioEditado)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == funcionarioEditado.Id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum funcionario com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            funcionario = funcionarioEditado;
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Funcionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    //implementação do delete funcionario por id
    public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
       ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

       try
       {
        FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = "Nenhum funcionario com esse registro encontrado";
            serviceResponse.Sucesso = false;
        }
        _context.Funcionarios.Remove(funcionario);
        _context.SaveChanges();
        
        serviceResponse.Dados = _context.Funcionarios.ToList();
       }
       catch (Exception e)
       {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
       }
       
       return serviceResponse;
    }

    //implementação inativa funcionario
    public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum funcionario com esse registro encontrado";
                serviceResponse.Sucesso = false;
            }
            funcionario.Ativo = false;
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Funcionarios.ToList();
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