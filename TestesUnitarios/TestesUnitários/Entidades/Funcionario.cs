using System;
using System.Collections.Generic;
using System.Text;

namespace TestesUnitários.Projeto.Entidades
{
    public class Funcionario
    {
        public Funcionario(int valorHora)
        {
            ValorHora = valorHora;
        }
        public int ValorHora { get; private set; }
    }
}
