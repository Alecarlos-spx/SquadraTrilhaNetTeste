using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Aula2ExemploCrud.DTO.Medico.AtualizarMedico;
using Bogus;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico.Builder
{
    public class AtualizarMedicoRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");

        private readonly AtualizarMedicoRequest _atualizarMedicoRequest;

        public AtualizarMedicoRequestBuilder()
        {
            _atualizarMedicoRequest = new AtualizarMedicoRequest();


            _atualizarMedicoRequest.nome = _faker.Random.String(40);
            _atualizarMedicoRequest.especialidade = _faker.Random.String(40);
            _atualizarMedicoRequest.telefone = _faker.Phone.PhoneNumber("####-####");
            _atualizarMedicoRequest.especialidade = _faker.Random.String(40);
            _atualizarMedicoRequest.crm = _faker.Random.String(10);


        }


        public AtualizarMedicoRequestBuilder withNameLength(int tamanho)
        {
            _atualizarMedicoRequest.nome = _faker.Random.String(tamanho);
            return this;
        }

        public AtualizarMedicoRequest Build()
        {
            return _atualizarMedicoRequest;
        }


    }
}
