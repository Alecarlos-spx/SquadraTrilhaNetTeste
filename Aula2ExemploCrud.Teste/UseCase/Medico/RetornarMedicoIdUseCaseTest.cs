using Aula2ExemploCrud.Bordas___Interfaces.UseCases.Repositorio;
using Aula2ExemploCrud.Bordas_Interfaces.Adapter;
using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Aula2ExemploCrud.DTO.Medico.RetornaMedicoId;
using Aula2ExemploCrud.Teste.UseCase.Medico.Builder;
using Aula2ExemploCrud.UseCase.Medico;
using FluentAssertions;
using Moq;
using System;
using Xunit;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico
{

    public class RetornarMedicoIdUseCaseTest
    {
        private readonly Mock<IRepositorioMedicos> _repositorioMedicos;
        private readonly Mock<IRetornarMedicoIdAdapter> _adapter;
        private readonly RetornarMedicoIdUseCase _useCase;

        public RetornarMedicoIdUseCaseTest()
        {
            _repositorioMedicos = new Mock<IRepositorioMedicos>();
            _adapter = new Mock<IRetornarMedicoIdAdapter>();
            _useCase = new RetornarMedicoIdUseCase(_repositorioMedicos.Object, _adapter.Object);
        }

        [Fact]
        public void Medico_RetornaMedicoId_QuandoRetornarSucesso()
        {
            var request = new RetornarMedicoIdRequestBuilder().Build();
            var response = new RetornarMedicoIdResponse();

            var medico = new MedicoEntities();

            int id = 1;
            request.id = id;

            _repositorioMedicos.Setup(repositorio => repositorio.GetId(id)).Returns(medico);

            medico.id = id;

            response.msg.Add("Pesquisa realizada com sucesso!");

                
            _adapter.Setup(adapter => adapter.converterMedicoParaResponse(medico)).Returns(response);

            //Act
                //Chamar as funções
                var result = _useCase.Executar(request);

            //Assert
                //As regras dos testes
                response.Should().BeEquivalentTo(result);
        }


        [Fact]
        public void Medico_AdicionarMedico_QuandoRepositorioExcecao()
        {
            var request = new RetornarMedicoIdRequestBuilder().Build();
            var response = new RetornarMedicoIdResponse();

            var medico = new MedicoEntities();

            int id = 1;

            _repositorioMedicos.Setup(repositorio => repositorio.GetId(id)).Throws(new Exception());

      
            response.msg.Add("Erro ao pesquisar o médico");

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request);

            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);
        }



    }
}
