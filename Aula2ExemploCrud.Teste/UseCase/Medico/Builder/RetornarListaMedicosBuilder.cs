using Aula2ExemploCrud.DTO.Medico.RetornaListaMedicos;
using Aula2ExemploCrud.DTO.Medico.RetornaMedicoId;
using Bogus;
using System.Collections.Generic;
using MedicoEntities = Aula2ExemploCrud.Entities.Medico;

namespace Aula2ExemploCrud.Teste.UseCase.Medico.Builder
{
    public class RetornarListaMedicosBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");

        private readonly RetornarListaMedicosResponse _retornaListaMedicosRequest;

        public RetornarListaMedicosBuilder()
        {
            _retornaListaMedicosRequest = new RetornarListaMedicosResponse();

            var medicoFaker = new Faker<MedicoEntities>("pt_BR")
               .RuleFor(c => c.id, f => f.IndexFaker)
               .RuleFor(c => c.nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
               .RuleFor(c => c.crm, f => f.Random.String(10))
               .RuleFor(c => c.especialidade, f => f.Random.String(40))

               .RuleFor(c => c.telefone, f => f.Phone.PhoneNumber("####-####"));

            //.RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
            //.RuleFor(c => c.Endereco, f => f.Address.StreetAddress())
            //.RuleFor(c => c.Nascimento, f => f.Date.Recent(100))
            //.RuleFor(c => c.Sexo, f => f.PickRandom(new string[] { "masculino", "feminino" }))
            //.RuleFor(c => c.Ativo, f => f.PickRandomParam(new bool[] { true, true, false }))
            //.RuleFor(o => o.Renda, f => f.Random.Decimal(500, 2000));
            var listaMedicos = medicoFaker.Generate(10);

            foreach (var item in listaMedicos.ToArray())
            {
                _retornaListaMedicosRequest.medicos.Add(item);
            }

        }


        public static List<MedicoEntities> ListaMedicosFake()
        {
            var medicoFaker = new Faker<MedicoEntities>("pt_BR")
                .RuleFor(c => c.id, f => f.IndexFaker)
                .RuleFor(c => c.nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(c => c.crm, f => f.Random.String(10))
                .RuleFor(c => c.especialidade, f => f.Random.String(40))

                .RuleFor(c => c.telefone, f => f.Phone.PhoneNumber("####-####"));

            //.RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
            //.RuleFor(c => c.Endereco, f => f.Address.StreetAddress())
            //.RuleFor(c => c.Nascimento, f => f.Date.Recent(100))
            //.RuleFor(c => c.Sexo, f => f.PickRandom(new string[] { "masculino", "feminino" }))
            //.RuleFor(c => c.Ativo, f => f.PickRandomParam(new bool[] { true, true, false }))
            //.RuleFor(o => o.Renda, f => f.Random.Decimal(500, 2000));
            var listaMedicos = medicoFaker.Generate(10);
            return listaMedicos;
        }


        public RetornarListaMedicosResponse Build()
        {
            return _retornaListaMedicosRequest;
        }


    }
}

