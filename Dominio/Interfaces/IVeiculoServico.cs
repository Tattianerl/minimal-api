
using MinimalApi.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> Todos(int? pagina, string? nome = null, string? marca = null );
        Veiculo? BuscaPorId(int Id);
        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}