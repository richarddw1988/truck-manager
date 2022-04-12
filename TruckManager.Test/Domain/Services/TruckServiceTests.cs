using Moq;
using System;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Domain.Interfaces.Services;
using TruckManager.Domain.Services;
using Xunit;

namespace TruckManager.Test.Application.Services
{
    public class TruckServiceTests
    {
        public TruckServiceTests()
        {
            
        }

        [Fact]
        public void Add_NaoDevePermitirAdicionarCaminhoesComModelosInativos()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 4,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 4,
                    Ativo = false,
                    Nome = "FMX"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(4)).Returns(new Modelo()
            {
                Id = 4,
                Ativo = false,
                Nome = "FMX"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Add(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O modelo informado ao inserir está inativo.", ex.Message);
        }


        [Fact]
        public void Add_NaoDevePermitirAdicionarCaminhoesComAnoModeloMenorDoQueAtual()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(-1).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Add(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano do modelo informado ao inserir deve ser o ano atual ou o subsequente.", ex.Message);
        }

        [Fact]
        public void Add_NaoDevePermitirAdicionarCaminhoesComAnoModeloMaiorDoQueSubsequente()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(2).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Add(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano do modelo informado ao inserir deve ser o ano atual ou o subsequente.", ex.Message);
        }

        [Fact]
        public void Add_NaoDevePermitirAdicionarCaminhoesComAnoFabricacaoDiferenteDoAtual()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.AddYears(1).Year,
                AnoModelo = DateTime.Now.Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Add(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano de fabricação informado ao inserir deve ser o ano atual.", ex.Message);
        }



        [Fact]
        public void Add_DevePermitirAdicionarCaminhoesComAnoModeloIgualAnoSubsequente()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(1).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Add(entity));

            Assert.Null(ex);
        }

        //Verficar se está correto
        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhoesComModelosInativos()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 4,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 4,
                    Ativo = false,
                    Nome = "FMX"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(4)).Returns(new Modelo()
            {
                Id = 4,
                Ativo = false,
                Nome = "FMX"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Update(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O modelo informado ao atualizar está inativo.", ex.Message);
        }


        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhoesComAnoModeloMenorDoQueAtual()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(-1).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Update(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano do modelo informado ao atualizar deve ser o ano atual ou o subsequente.", ex.Message);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhoesComAnoModeloMaiorDoQueSubsequente()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(2).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Update(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano do modelo informado ao atualizar deve ser o ano atual ou o subsequente.", ex.Message);
        }

        [Fact]
        public void Update_NaoDevePermitirAlterarCaminhoesComAnoFabricacaoDiferenteDoAtual()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.AddYears(1).Year,
                AnoModelo = DateTime.Now.Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Update(entity));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("O ano de fabricação informado ao atualizar deve ser o ano atual.", ex.Message);
        }



        [Fact]
        public void Update_DevePermitirAlterarCaminhoesComAnoModeloIgualAnoSubsequente()
        {
            var entity = new Truck()
            {
                Id = 0,
                IdModelo = 2,
                Nome = "TESTE",
                Modelo = new Modelo()
                {
                    Id = 2,
                    Ativo = true,
                    Nome = "FH"
                },
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.AddYears(1).Year,
            };

            var modeloRepository = new Mock<IModeloRepository>();

            modeloRepository.Setup(x => x.Find(2)).Returns(new Modelo()
            {
                Id = 2,
                Ativo = true,
                Nome = "FH"
            });

            var truckService = new TruckService(new Mock<ITruckRepository>().Object, modeloRepository.Object);

            var ex = Record.Exception(() => truckService.Update(entity));

            Assert.Null(ex);
        }
    }
}