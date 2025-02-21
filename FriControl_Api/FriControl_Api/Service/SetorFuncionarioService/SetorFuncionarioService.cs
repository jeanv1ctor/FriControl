using FriControl_Api.Data;
using FriControl_Api.DTO.SetorFuncionario;
using FriControl_Api.Models;

namespace FriControl_Api.Service.SetorFuncionarioService;

public class SetorFuncionarioService : ISetorFuncionarioInterface
{
    private AppDbContext _context;

    public SetorFuncionarioService(AppDbContext context)
    {
        _context = context;
    }
    
    //implementação do get setor funcionario
    public async Task<ServiceResponse<List<SetorFuncionarioModel>>> GetSetor()
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse = new ServiceResponse<List<SetorFuncionarioModel>>();

        try
        {
            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum setor foi encontrado";
            }
            serviceResponse.Dados = _context.SetorFuncionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do create setor funcionario
    public async Task<ServiceResponse<List<SetorFuncionarioModel>>> CreateSetor(CreateSetorDto setorDto)
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse = new ServiceResponse<List<SetorFuncionarioModel>>();

        try
        {
            if (setorDto == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum setor foi encontrado";
                serviceResponse.Sucesso = false;
            }

            var setor = new SetorFuncionarioModel
            {
                NomeSetor = setorDto.NomeSetor,
                DataDeAlteracao = setorDto.DataDeAlteracao,
                DataDeCriacao = setorDto.DataDeCriacao,
            };
            
            _context.SetorFuncionarios.Add(setor);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.SetorFuncionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = "As informações do setor do funcionário estão vazias";
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implemetnação do get setor por id
    public async Task<ServiceResponse<SetorFuncionarioModel>> GetSetorById(int id)
    {
        ServiceResponse<SetorFuncionarioModel> serviceResponse = new ServiceResponse<SetorFuncionarioModel>();
        try
        {

            SetorFuncionarioModel setor = _context.SetorFuncionarios.FirstOrDefault(s => s.Id == id);
            if (setor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum setor foi encontrado";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Dados = setor;
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do update setor 
    public async Task<ServiceResponse<List<SetorFuncionarioModel>>> UpdateSetor(UpdateSetorDto setorEditado)
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse = new ServiceResponse<List<SetorFuncionarioModel>>();

        try
        {
            SetorFuncionarioModel setor = _context.SetorFuncionarios.FirstOrDefault(x => x.Id == setorEditado.Id);
            if (setor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum setor foi encontrado";
                serviceResponse.Sucesso = false;
            }
            setor.NomeSetor = setorEditado.NomeSetor;
            setor.DataDeAlteracao = DateTime.Now;
            
            _context.SetorFuncionarios.Update(setor);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.SetorFuncionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    //implementação do delete setor funcionario
    public async Task<ServiceResponse<List<SetorFuncionarioModel>>> DeteleSetor(int id)
    {
        ServiceResponse<List<SetorFuncionarioModel>> serviceResponse =
            new ServiceResponse<List<SetorFuncionarioModel>>();
        try
        {
            SetorFuncionarioModel setor = _context.SetorFuncionarios.FirstOrDefault(x => x.Id == id);
            if (setor == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Nenhum setor foi encontrado";
                serviceResponse.Sucesso = false;
            }
            _context.SetorFuncionarios.Remove(setor);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.SetorFuncionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }
}