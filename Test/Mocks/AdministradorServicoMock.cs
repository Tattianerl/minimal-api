using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace Test.Tests
{
    [TestClass]
    public class VeiculoServicoTests
    {
        private DbContexto _contexto;
        private VeiculoServico _veiculoServico;

        [TestInitialize]
        public void Setup()
        {
            // Configurar o DbContexto em memória
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseInMemoryDatabase(databaseName: "TesteVeiculoDB")
                .Options;

            _contexto = new DbContexto(options);
            _veiculoServico = new VeiculoServico(_contexto);

            // Adicionar dados iniciais
            _contexto.Veiculos.AddRange(new List<Veiculo>
            {
                new Veiculo { Id = 1, Nome = "Carro A", Marca = "Marca A" },
                new Veiculo { Id = 2, Nome = "Carro B", Marca = "Marca B" }
            });

            _contexto.SaveChanges();
        }

        [TestMethod]
        public void Incluir_AdicionaVeiculo()
        {
            // Arrange
            var novoVeiculo = new Veiculo { Nome = "Carro C", Marca = "Marca C" };

            // Act
            _veiculoServico.Incluir(novoVeiculo);

            // Assert
            var veiculos = _contexto.Veiculos.ToList();
            Assert.AreEqual(3, veiculos.Count);
            Assert.AreEqual("Carro C", veiculos[2].Nome);
        }

        [TestMethod]
        public void Apagar_RemovesVeiculo()
        {
            // Arrange
            var veiculoParaRemover = _contexto.Veiculos.First(v => v.Id == 1);

            // Act
            _veiculoServico.Apagar(veiculoParaRemover);

            // Assert
            var veiculos = _contexto.Veiculos.ToList();
            Assert.AreEqual(1, veiculos.Count);
        }

        [TestMethod]
        public void Atualizar_AtualizaVeiculo()
        {
            // Arrange
            var veiculoParaAtualizar = _contexto.Veiculos.First(v => v.Id == 1);
            veiculoParaAtualizar.Nome = "Carro A Atualizado";

            // Act
            _veiculoServico.Atualizar(veiculoParaAtualizar);

            // Assert
            var veiculoAtualizado = _contexto.Veiculos.Find(1);
            Assert.AreEqual("Carro A Atualizado", veiculoAtualizado.Nome);
        }

        [TestMethod]
        public void BuscaPorId_RetornaVeiculo()
        {
            // Act
            var veiculo = _veiculoServico.BuscaPorId(1);

            // Assert
            Assert.IsNotNull(veiculo);
            Assert.AreEqual("Carro A", veiculo.Nome);
        }

        [TestMethod]
        public void Todos_RetornaListaVeiculos()
        {
            // Act
            var veiculos = _veiculoServico.Todos();

            // Assert
            Assert.AreEqual(2, veiculos.Count);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Limpar o banco de dados em memória após cada teste
            _contexto.Database.EnsureDeleted();
            _contexto.Dispose();
        }
    }
}
