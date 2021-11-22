using Projeto.Entidades;

namespace Projeto._3_Complementos.Fake
{
    public static class PessoaFake
    {
        public static string NOME = "mario";
        public static string CPF = "123.456.789.10";
        public static string RG = "254.875.965-1";
        public static int IDADE = 40;

        public static Pessoa ObterPessoa()
        {
            return new Pessoa { Idade = IDADE, Nome = NOME, Cpf = CPF, Rg = RG };
        }

        //public static Pessoa ObterPessoaMenorDeIdade()
        //{
        //    return new Pessoa { Idade = 15, Nome = NOME, Cpf = CPF, Rg = RG };
        //}
    }
}
