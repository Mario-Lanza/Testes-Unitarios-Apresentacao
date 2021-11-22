using TestesUnitários.Projeto.Entidades;

namespace Projeto._2_Aprofundamento
{
    public class CalculoSalario : ICalculoSalario
    {
        public ICalculoBonus calculoBonus;
        public int bonificacao = 0;
        public CalculoSalario(ICalculoBonus calculoBonus)
        {
            this.calculoBonus = calculoBonus;
        }

        public decimal Calcular(Funcionario funcionario, int horasTrabalhadas)
        {
            bonificacao = calculoBonus.Calcular(funcionario);

            return funcionario.ValorHora * horasTrabalhadas + bonificacao;
        }
    }
}
