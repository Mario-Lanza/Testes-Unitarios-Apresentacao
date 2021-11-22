using TestesUnitários.Projeto.Entidades;

namespace Projeto._2_Aprofundamento
{
    public interface ICalculoSalario
    {
        decimal Calcular(Funcionario funcionario, int horasTrabalhadas);
    }
}