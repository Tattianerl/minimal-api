using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Interfaces;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using MinimalApiDTOs;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _Contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _Contexto = contexto;
    }

     public Administrador? BuscaPorId(int Id)
    {
       return _Contexto.Administradores
                            .Where(a => a.Id == Id)
                            .FirstOrDefault();
        
    }

    public Administrador? Incluir(Administrador administrador)
    {
        _Contexto.Administradores.Add(administrador);
        _Contexto.SaveChanges();
        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        // Correção: FirstOrDefault()
        var adm = _Contexto.Administradores
                            .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
                            .FirstOrDefault();
        return adm;
    }

    public List<Administrador> Todos(int? pagina)
    {
        
        var query = _Contexto.Administradores.AsQueryable();
    
        int itensPorPagina = 10;

        if (pagina != null)
         query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

          return query.ToList();
    
    }

    public object Todos()
    {
        throw new NotImplementedException();
    }
}
