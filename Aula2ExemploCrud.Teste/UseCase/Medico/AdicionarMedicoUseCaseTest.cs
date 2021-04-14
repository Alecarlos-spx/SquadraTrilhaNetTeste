using Aula2ExemploCrud.Bordas___Interfaces.UseCases.Repositorio;
using Aula2ExemploCrud.Bordas_Interfaces.Adapter;
using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Aula2ExemploCrud.Teste.UseCase.Medico.Builder;
using Aula2ExemploCrud.UseCase.Medico;
using FluentAssertions;
using Moq;
using System;
using Xunit;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico
{

    public class AdicionarMedicoUseCaseTest
    {
        private readonly Mock<IRepositorioMedicos> _repositorioMedicos;
        private readonly Mock<IAdicionarMedicoAdapter> _adapter;
        private readonly AdicionarMedicoUseCase _useCase;

        public AdicionarMedicoUseCaseTest()
        {
            _repositorioMedicos = new Mock<IRepositorioMedicos>();
            _adapter = new Mock<IAdicionarMedicoAdapter>();
            _useCase = new AdicionarMedicoUseCase(_repositorioMedicos.Object, _adapter.Object);
        }

        [Fact]
        public void Medico_AdicionarMedico_QuandoRetornarSucesso()
        {
            //Entidade_O que vai estar_comportamento esperado

            //Arrange
                //criar as variáveis
                var request = new AdicionarMedicoRequestBuilder().Build();
                var response = new AdicionarMedicoResponse();

                var medico = new MedicoEntities();

                medico.id = 1;
                response.msg.Add("Adicionado com sucesso");
                response.id = medico.id;

                _repositorioMedicos.Setup(repositorio => repositorio.Add(medico)).Returns(medico.id);
                _adapter.Setup(adapter => adapter.converterRequestParaMedico(request)).Returns(medico);

            //Act
                //Chamar as funções
                var result = _useCase.Executar(request);

            //Assert
                //As regras dos testes
                response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Medico_AdicionarMedico_QuandoNomeMenorVinte()
        {
    
            //Arrange
            var request = new AdicionarMedicoRequestBuilder().withNameLength(10).Build();
            var response = new AdicionarMedicoResponse();

            //var medico = new MedicoEntities();
            //medico.id = 1;

            response.msg.Add("Erro ao adicionar o medico");
            response.erros.Add("Nome deve conter de 3 a 20 caracteres");

            //_repositorioMedicos.Setup(repositorio => repositorio.Add(medico)).Returns(medico.id);
            //_adapter.Setup(adapter => adapter.converterRequestParaMedico(request)).Returns(medico);

            //Act
            var result = _useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Medico_AdicionarMedico_QuandoRepositorioExcecao()
        {
            //Entidade_O que vai estar_comportamento esperado

            //Arrange
            //criar as variáveis
            var request = new AdicionarMedicoRequestBuilder().Build();
            var response = new AdicionarMedicoResponse();

            var medico = new MedicoEntities();

            medico.id = 1;
            response.msg.Add("Erro ao adicionar o medico");
  

            _adapter.Setup(adapter => adapter.converterRequestParaMedico(request)).Returns(medico);
            _repositorioMedicos.Setup(repositorio => repositorio.Add(medico)).Throws(new Exception());

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request);

            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);
        }



    }
}
