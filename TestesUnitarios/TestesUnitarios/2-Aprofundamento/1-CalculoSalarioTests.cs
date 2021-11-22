using NSubstitute;
using NUnit.Framework;
using Projeto._2_Aprofundamento;
using TestesUnitários.Projeto.Entidades;

namespace TestesUnitarios._2_Aprofundamento
{
    [TestFixture]
    public class CalculoSalarioTests
    {
        public ICalculoSalario calculoSalario;
        public ICalculoBonus calculoBonus;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            calculoBonus = Substitute.For<ICalculoBonus>();

            calculoBonus.Calcular(Arg.Any<Funcionario>()).Returns(1000);
            calculoBonus.Calcular(Arg.Is<Funcionario>(f => f.ValorHora == 30)).Returns(1500);
            
            //nao utilizar instancias
            //var instanciaCalculoBonus = new CalculoBonus();

            calculoSalario = new CalculoSalario(calculoBonus);
        }

        [Test]
        public void Deve_calcular_o_salario()
        {
            const int valorHora = 20;
            const int horasTrabalhadas = 160;
            const int esperado = 4200;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }

        [Test]
        public void Deve_calcular_o_salario_com_funcionario_diferente()
        {
            const int valorHora = 30;
            const int horasTrabalhadas = 160;
            const int esperado = 6300;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }
    }
}
