using NUnit.Framework;
using System.Collections.Generic;
using TestesUnitários.Inicio;
using TestesUnitários.Projeto.Entidades;

namespace TestesUnitarios.Inicio
{
    [TestFixture]
    public class CalculoSalarioTests
    {
        public ICalculoSalario calculoSalario;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            calculoSalario = new CalculoSalario();
        }

        [Test]
        public void Deve_calcular_o_salario()
        {
            const int valorHora = 20;
            const int horasTrabalhadas = 160;
            const int esperado = 3200;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }

        [Test]
        public void Deve_calcular_o_salario_sem_horas_trabalhadas()
        {
            const int valorHora = 20;
            const int horasTrabalhadas = 0;
            const int esperado = 0;
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }

        [TestCase(20, 160, 3200, TestName = "Deve calcular o salario TestCase")]//só aceita constantes.
        [TestCase(20, 0, 0, TestName = "Deve calcular o salario sem horas trabalhadas TestCase")]
        public void Deve_calcular_o_salario_TestCase(int valorHora, int horasTrabalhadas, int esperado)
        {
            var funcionario = new Funcionario(valorHora);

            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }

        [TestCaseSource(nameof(SalarioCaseData))]
        public void Nao_deve_calcular_o_salario_TestCaseSource(Funcionario funcionario, int horasTrabalhadas, int esperado)
        {
            var salario = calculoSalario.Calcular(funcionario, horasTrabalhadas);

            Assert.AreEqual(esperado, salario);
        }

        public static IEnumerable<TestCaseData> SalarioCaseData()
        {
            yield return new TestCaseData(new Funcionario(20), 160, 3200).SetName("Deve calcular o salario TestCaseSource");
            yield return new TestCaseData(new Funcionario(20), 0, 0).SetName("Deve calcular o salario sem horas trabalhadas TestCaseSource");
        }
    }
}
