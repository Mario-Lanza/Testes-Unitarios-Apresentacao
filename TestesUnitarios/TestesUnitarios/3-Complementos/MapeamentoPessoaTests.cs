using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Projeto._3_Complementos;
using Projeto._3_Complementos.Fake;
using Projeto.Entidades;
using System;

namespace TestesUnitarios._3_Complementos
{
    [TestFixture]
    public class MapeamentoPessoaTests
    {
        public IMapeamentoPessoa mapeamentoPessoa;
        public IRepositorioPessoa repositorioPessoa;
        private Pessoa pessoaEsperada;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            repositorioPessoa = Substitute.For<IRepositorioPessoa>();

            repositorioPessoa.When(x => x.Salvar(Arg.Any<Pessoa>())).Do(args => {
                pessoaEsperada = args.Arg<Pessoa>();
            });

            mapeamentoPessoa = new MapeamentoPessoa(repositorioPessoa);
        }

        [TearDown]
        public void TearDown()
        {
            repositorioPessoa.ClearReceivedCalls();
            pessoaEsperada = null;
        }

        [Test]
        public void Deve_mapear_pessoa_e_salvar()
        {
            var nome = "mario";
            var cpf = "123.456.789.10";
            var rg = "254.875.965-1";
            var idade = 40;

            //não tem retorno para poder validar!!
            mapeamentoPessoa.Mapear(nome, cpf, rg, idade);

            repositorioPessoa.Received(1).Salvar(Arg.Any<Pessoa>());
            //remover criação da pessoa
        }

        [Test]
        public void Deve_mapear_pessoa_e_salvar_validando_pessoa()
        {
            var nome = "mario";
            var cpf = "123.456.789.10";
            var rg = "254.875.965-1";
            var idade = 40;

            mapeamentoPessoa.Mapear(nome, cpf, rg, idade);

            //repositorioPessoa.Received(1).Salvar(new Pessoa { Nome = nome, Cpf = cpf, Rg = rg, Idade = idade});

            //repositorioPessoa.Received(1).Salvar(Arg.Is<Pessoa>(p => p.Nome == nome && p.Cpf == cpf && p.Rg == rg && p.Idade == idade));

            Assert.AreEqual(nome, pessoaEsperada.Nome);
            Assert.AreEqual(cpf, pessoaEsperada.Cpf);
            Assert.AreEqual(rg, pessoaEsperada.Rg);
            Assert.AreEqual(idade, pessoaEsperada.Idade);
        }

        [Test]
        public void Deve_mapear_pessoa_e_salvar_validando_pessoa_com_fluent()
        {
            var nome = "mario";
            var cpf = "123.456.789.10";
            var rg = "254.875.965-1";
            var idade = 40;

            var expected = new Pessoa { Idade = idade, Nome = nome, Cpf = cpf, Rg = rg };

            mapeamentoPessoa.Mapear(nome, cpf, rg, idade);

            repositorioPessoa.Received(1).Salvar(Arg.Any<Pessoa>());

            pessoaEsperada.Should().BeEquivalentTo(expected);

            //voce pode esquecer algum parametro importante enquanto mapeia 1 a 1.
        }

        [Test]
        public void Deve_mapear_pessoa_e_salvar_validando_pessoa_com_fluent_utilizando_fakes()
        {
            var expected = PessoaFake.ObterPessoa();

            mapeamentoPessoa.Mapear(PessoaFake.NOME, PessoaFake.CPF, PessoaFake.RG, PessoaFake.IDADE);

            repositorioPessoa.Received(1).Salvar(Arg.Any<Pessoa>());

            pessoaEsperada.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Deve_mapear_pessoa_e_salvar_validando_pessoa_com_fluent_utilizando_fakes_com_falso_positivo()
        {
            mapeamentoPessoa.Mapear(PessoaFake.NOME, PessoaFake.CPF, PessoaFake.RG, PessoaFake.IDADE);

            //pessoaEsperada.Should().BeEquivalentTo(expected);
            //ao invés de ter essa validação em cada teste, porque não utilizar no proprio When/Do
        }

        [Test]
        public void Deve_ocorrer_erro_quando_nome_esta_vazio()
        {
            Action act = () => mapeamentoPessoa.Mapear(null, PessoaFake.CPF, PessoaFake.RG, PessoaFake.IDADE);

            act.Should().Throw<ArgumentNullException>();
        }

        private int Quantos_testes_fazer(string valor1, string valor2, string valor3)
        {
            var resultado = 0;
            if (valor1 == null)
                resultado += 1;

            if (valor2 == null)
                resultado += 2;

            if (valor3 == null)
                resultado += 3;

            // * * *
            // * * -
            // * - *
            // - * *
            // * - -
            // - * -
            // - - *
            // - - -

            //pelo menos 8 testes num método desses!
            //Deve ter um calculo de complexidade que verifica isso.

            return resultado;
        }
    }
}
