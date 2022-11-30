using AutoMapper;
using Moq;
using System;
using TruckManager.Application.Services;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Domain.Interfaces.Services;
using TruckManager.Domain.Services;
using Xunit;

namespace TruckManager.Test.Application.Services
{
    public class TruckAppTests
    {
        public TruckAppTests()
        {
            
        }

        [Fact]
        public void Add_DevePermitirInclusaoCaminhao()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };
         
            var ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.Null(ex);
        }

        [Fact]
        public void Add_NaoDevePermitirInclusaoCaminhaoNomeIgualNuloOuVazio()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = null,
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);

            truckViewModel.Nome = string.Empty;

            ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);
        }

        [Fact]
        public void Add_NaoDevePermitirInclusaoCaminhaoAnoFabricacaoIgualNuloOuZero()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = "TESTE",
                AnoFabricacao = null,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);

            truckViewModel.AnoFabricacao = 0;

            ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);
        }

        [Fact]
        public void Add_NaoDevePermitirInclusaoCaminhaoAnoModeloIgualZeroOuNulo()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = 0,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);

            truckViewModel.AnoModelo = null;

            ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);
        }


        [Fact]
        public void Add_NaoDevePermitirInclusaoCaminhaoIdModeloIgualZeroOuNulo()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 0,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);

            truckViewModel.IdModelo = null;

            ex = Record.Exception(() => truckApp.Add(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para incluir um novo modelo.", ex.Message);
        }

        [Fact]
        public void Update_DevePermitirAlterarCaminhao()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 1,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.Null(ex);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhaoComIdIgualZeroOuNulo()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 0,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor selecionar o registro para ser atualizado.", ex.Message);

            truckViewModel.Id = null;

            ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor selecionar o registro para ser atualizado.", ex.Message);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhaoNomeIgualNuloOuVazio()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 1,
                Nome = null,
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);

            truckViewModel.Nome = string.Empty;

            ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhaoAnoFabricacaoIgualNuloOuZero()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 1,
                Nome = "TESTE",
                AnoFabricacao = null,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);

            truckViewModel.AnoFabricacao = 0;

            ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhaoAnoModeloIgualZeroOuNulo()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 1,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = 0,
                IdModelo = 3,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);

            truckViewModel.AnoModelo = null;

            ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);
        }


        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhaoIdModeloIgualZeroOuNulo()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var truckViewModel = new TruckViewModel()
            {
                Id = 1,
                Nome = "TESTE",
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                IdModelo = 0,
                Modelo = "FM",
                Selecionado = true
            };

            var ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);

            truckViewModel.IdModelo = null;

            ex = Record.Exception(() => truckApp.Update(truckViewModel));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor preencher todos os campos para atualizar o modelo.", ex.Message);
        }

        [Fact]
        public void Delete_DevePermitirExcluirCaminhao()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var ex = Record.Exception(() => truckApp.Delete(1));

            Assert.Null(ex);
        }


        [Fact]
        public void Delete_NaoDevePermitirExcluirCaminhaoIdIgualZero()
        {
            var truckApp = new TruckApp(new Mock<IMapper>().Object, new Mock<ITruckService>().Object);

            var ex = Record.Exception(() => truckApp.Delete(0));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Favor selecionar o registro para ser excluído.", ex.Message);
        }
    }
}