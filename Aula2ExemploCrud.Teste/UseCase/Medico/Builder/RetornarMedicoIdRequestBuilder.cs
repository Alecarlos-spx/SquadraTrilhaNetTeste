using Aula2ExemploCrud.DTO.Medico.RetornaMedicoId;
using Bogus;

namespace Aula2ExemploCrud.Teste.UseCase.Medico.Builder
{
    public class RetornarMedicoIdRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");

        private readonly RetornarMedicoIdRequest _retornaMedicoIdRequest;

        public RetornarMedicoIdRequestBuilder()
        {
            _retornaMedicoIdRequest = new RetornarMedicoIdRequest();


            _retornaMedicoIdRequest.nome = _faker.Random.String(40);
            _retornaMedicoIdRequest.especialidade = _faker.Random.String(40);
            _retornaMedicoIdRequest.telefone = _faker.Phone.PhoneNumber("####-####");
            _retornaMedicoIdRequest.especialidade = _faker.Random.String(40);
            _retornaMedicoIdRequest.crm = _faker.Random.String(10);


        }

        public RetornarMedicoIdRequestBuilder withNameLength(int tamanho)
        {
            _retornaMedicoIdRequest.nome = _faker.Random.String(tamanho);
            return this;
        }

        public RetornarMedicoIdRequest Build()
        {
            return _retornaMedicoIdRequest;
        }


    }
}
