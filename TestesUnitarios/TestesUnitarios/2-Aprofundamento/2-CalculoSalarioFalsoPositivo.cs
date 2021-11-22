using NSubstitute;
using NUnit.Framework;
using Projeto._2_Aprofundamento;
using TestesUnitários.Projeto.Entidades;

namespace TestesUnitarios._2_Aprofundamento
{
    [TestFixture]
    public class CalculoSalarioFalsoPositivo
    {
        public ICalculoSalario calculoSalario;
        public ICalculoBonus calculoBonus;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            calculoBonus = Substitute.For<ICalculoBonus>();

            calculoSalario = new CalculoSalario(calculoBonus);
        }

        [TearDown]
        public void TearDown()
        {
            calculoBonus.ClearReceivedCalls();
        }

        [Test]
        public void Deve_calcular_o_salario_com_falso_positivo()
        {
            const int valorHora = 20;
            const int horasTrabalhadas = 160;
            const int esperado = 3200;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            //comentar calcularBonus
            Assert.AreEqual(esperado, salario);
            //sempre tente fazer seu teste quebrar primeiro pra depois faze-lo passar.
            calculoBonus.Received(1).Calcular(Arg.Any<Funcionario>());
        }

        [Test]
        public void Deve_calcular_o_salario()//rodar ao mesmo tempo para received quebrar
        {
            const int valorHora = 20;
            const int horasTrabalhadas = 160;
            const int esperado = 3200;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
            calculoBonus.Received(1).Calcular(Arg.Any<Funcionario>());
        }
    }
}
