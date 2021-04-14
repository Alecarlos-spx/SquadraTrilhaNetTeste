using Aula2ExemploCrud.Bordas___Interfaces.UseCases.Repositorio;
using Aula2ExemploCrud.Bordas_Interfaces.Adapter;
using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Aula2ExemploCrud.DTO.Medico.RetornaListaMedicos;
using Aula2ExemploCrud.DTO.Medico.RetornaMedicoId;
using Aula2ExemploCrud.Teste.UseCase.Medico.Builder;
using Aula2ExemploCrud.UseCase.Medico;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico
{

    public class RetornarListaMedicosUseCaseTest
    {
        private readonly Mock<IRepositorioMedicos> _repositorioMedicos;
        private readonly RetornarListaMedicosUseCase _useCase;

        public RetornarListaMedicosUseCaseTest()
        {
            _repositorioMedicos = new Mock<IRepositorioMedicos>();

            _useCase = new RetornarListaMedicosUseCase(_repositorioMedicos.Object);
        }

        [Fact]
        public void Medico_RetornaListaMedicos_QuandoRetornarSucesso()
        {
            //var listaMedicosFake = new RetornarListaMedicosBuilder().Build();
            var response = new RetornarListaMedicosResponse();

            var medicos = new List<MedicoEntities>();

            var medico = new MedicoEntities
            {
                id = 1,
                nome = "Marcos Adamastor Belgrado",
                especialidade = "Cirurgião",
                crm = "1252145892",
                telefone = "112526-8547",
                situacao = true
            };

            medicos.Add(medico);
            response.medicos.Add(medico);



            //foreach (var item in listaMedicosFake.medicos.ToArray())
            //{
            //    response.medicos.Add(item);
            //}

            



            _repositorioMedicos.Setup(repositorio => repositorio.Get()).Returns(medicos);

            response.msg.Add("Lista de Médicos!");

                
            //_adapter.Setup(adapter => adapter.converterMedicoParaResponse(medico)).Returns(response);

            //Act
                //Chamar as funções
                var result = _useCase.Executar();

            //Assert
                //As regras dos testes
                response.Should().BeEquivalentTo(result);
        }


        [Fact]
        public void Medico_AdicionarMedico_QuandoRepositorioExcecao()
        {
            //var request = new RetornarListaMedicosRequestBuilder().Build();
            var response = new RetornarListaMedicosResponse();

            var medico = new MedicoEntities();

            _repositorioMedicos.Setup(repositorio => repositorio.Get()).Throws(new Exception());

      
            response.msg.Add("Erro ao listar os médicos!");

            //Act
            //Chamar as funções
            var result = _useCase.Executar();

            //Assert
            //As regras dos testes
            response.Should().BeEquivalentTo(result);
        }



    }
}
