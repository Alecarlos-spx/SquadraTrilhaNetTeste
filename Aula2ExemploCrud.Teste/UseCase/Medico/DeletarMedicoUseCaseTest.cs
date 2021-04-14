using Aula2ExemploCrud.Bordas___Interfaces.UseCases.Repositorio;
using Aula2ExemploCrud.Bordas_Interfaces.Adapter;
using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Aula2ExemploCrud.DTO.Medico.DeletarMedico;
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

    public class DeletarMedicoUseCaseTest
    {
        private readonly Mock<IRepositorioMedicos> _repositorioMedicos;

        
        private readonly DeletarMedicoUseCase _useCase;

        public DeletarMedicoUseCaseTest()
        {
            _repositorioMedicos = new Mock<IRepositorioMedicos>();
            _useCase = new DeletarMedicoUseCase(_repositorioMedicos.Object);
        }

        [Fact]
        public void Medico_DeletarMedico_QuandoRetornarSucesso()
        {
            var requestid = new RetornarMedicoIdRequestBuilder().Build();


            var request = new DeletarMedicoRequest();
            var response = new DeletarMedicoResponse();

            var medico = new MedicoEntities();

            int id = 1;
            request.id = id;

            _repositorioMedicos.Setup(repositorio => repositorio.GetId(id)).Returns(medico);



            //_repositorioMedicos.Setup(repositorio => repositorio.Delete(id));

            request.id = id;
           

            response.msg.Add("Excluido com sucesso!");


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
            var request = new DeletarMedicoRequest();
            var response = new DeletarMedicoResponse();

            var medico = new MedicoEntities();

            int id = 1;

            _repositorioMedicos.Setup(repositorio => repositorio.Delete(id)).Throws(new Exception());

            request.id = id;

            response.msg.Add("Erro ao excluir o médico!");

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request);

            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);
        }



    }
}
