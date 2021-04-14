using Aula2ExemploCrud.DTO.Medico.AdicionarMedico;
using Bogus;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico.Builder
{
    public class AdicionarMedicoRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");

        private readonly AdicionarMedicoRequest _adicionarMedicoRequest;

        public AdicionarMedicoRequestBuilder()
        {
            _adicionarMedicoRequest = new AdicionarMedicoRequest();

            _adicionarMedicoRequest.nome = _faker.Random.String(40);
            _adicionarMedicoRequest.especialidade = _faker.Random.String(40);
            _adicionarMedicoRequest.telefone = _faker.Phone.PhoneNumber("####-####");
            _adicionarMedicoRequest.especialidade = _faker.Random.String(40);
            _adicionarMedicoRequest.crm = _faker.Random.String(10);


        }


        public AdicionarMedicoRequestBuilder withNameLength(int tamanho)
        {
            _adicionarMedicoRequest.nome = _faker.Random.String(tamanho);
            return this;
        }

        public AdicionarMedicoRequest Build()
        {
            return _adicionarMedicoRequest;
        }


    }
}
