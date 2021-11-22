using TestesUnitários.Projeto.Entidades;

namespace TestesUnitários.Inicio
{
    public interface ICalculoSalario
    {
        decimal Calcular(Funcionario funcionario, int horasTrabalhadas);
    }
}