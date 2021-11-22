using Projeto.Entidades;
using System;

namespace Projeto._3_Complementos
{
    public class MapeamentoPessoa : IMapeamentoPessoa
    {
        private readonly IRepositorioPessoa repositorioPessoa;
        private Pessoa pessoa;
        public MapeamentoPessoa(IRepositorioPessoa repositorioPessoa)
        {
            this.repositorioPessoa = repositorioPessoa;
        }
        public void Mapear(string nome, string cpf, string rg, int idade)
        {
            if(nome == null)
                throw new ArgumentNullException(nome);

            pessoa = new Pessoa { Nome = nome, Cpf = cpf, Rg = rg, Idade = idade };

            repositorioPessoa.Salvar(pessoa);
        }
    }
}
