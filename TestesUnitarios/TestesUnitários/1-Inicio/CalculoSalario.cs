using TestesUnitários.Projeto.Entidades;

namespace TestesUnitários.Inicio
{
    public class CalculoSalario : ICalculoSalario
    {
        public decimal Calcular(Funcionario funcionario, int horasTrabalhadas)
        {
            return funcionario.ValorHora * horasTrabalhadas;
        }
    }
}
