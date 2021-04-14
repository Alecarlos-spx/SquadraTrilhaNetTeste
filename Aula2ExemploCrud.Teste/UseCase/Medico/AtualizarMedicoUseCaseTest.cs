using Aula2ExemploCrud.Bordas___Interfaces.UseCases.Repositorio;
using Aula2ExemploCrud.Bordas_Interfaces.Adapter;
using Aula2ExemploCrud.DTO.Medico.AtualizarMedico;
using Aula2ExemploCrud.Teste.UseCase.Medico.Builder;
using Aula2ExemploCrud.UseCase.Medico;
using FluentAssertions;
using Moq;
using System;
using Xunit;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico
{
    public class AtualizarMedicoUseCaseTest
    {
        private readonly Mock<IRepositorioMedicos> _repositorioMedicos;
        private readonly Mock<IAtualizarMedicoAdapter> _adapter;
        private readonly AtualizarMedicoUseCases _useCase;

        public AtualizarMedicoUseCaseTest()
        {
            _repositorioMedicos = new Mock<IRepositorioMedicos>();
            _adapter = new Mock<IAtualizarMedicoAdapter>();
            _useCase = new AtualizarMedicoUseCases(_repositorioMedicos.Object, _adapter.Object);
        }

        [Fact]
        public void Medico_AtualizarMedico_QuandoRetornarSucesso()
        {
            var request = new AtualizarMedicoRequestBuilder().Build();
            var response = new AtualizarMedicoResponse();

            var medico = new MedicoEntities();

            int id = 1;

            _repositorioMedicos.Setup(repositorio => repositorio.GetId(id)).Returns(medico);

            medico.id = id;

            response.msg.Add("Atualizado com sucesso");
            response.id = medico.id;

            _adapter.Setup(adapter => adapter.converterRequestParaMedico(request)).Returns(medico);
            _repositorioMedicos.Setup(repositorio => repositorio.Update(medico)).Returns(medico.id);

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request, id);


            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Medico_AtualizarMedico_QuandoNomeMenorVinte()
        {
            var request = new AtualizarMedicoRequestBuilder().withNameLength(10).Build();
            var response = new AtualizarMedicoResponse();

            var medico = new MedicoEntities();

            int id = 1;

            _repositorioMedicos.Setup(repositorio => repositorio.GetId(id)).Returns(medico);

            medico.id = id;

            response.msg.Add("Erro ao atualizar o médico");
            response.erros.Add("Nome deve conter de 3 a 20 caracteres");
            

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request, id);


            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);




        }

        [Fact]
        public void Medico_AtualizarMedico_QuandoRepositorioExcecao()
        {
            
            var request = new AtualizarMedicoRequestBuilder().Build();
            var response = new AtualizarMedicoResponse();

            var medico = new MedicoEntities();
            int id = 1;
            response.msg.Add("Erro ao atualizar o médico");

            medico.id = id;

            _adapter.Setup(adapter => adapter.converterRequestParaMedico(request)).Returns(medico);
            _repositorioMedicos.Setup(repositorio => repositorio.Add(medico)).Throws(new Exception());

            //Act
            //Chamar as funções
            var result = _useCase.Executar(request, id);

            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);
        }
    }
}
