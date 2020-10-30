using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravarLerArquivo.Entities
{
    public class Funcionario
    {
        private int idFuncionario;
        private string nome;
        private decimal salario;
        private DateTime dataAdmissao;

        public Funcionario(int idFuncionario, string nome, decimal salario, DateTime dataAdmissao)
        {
            this.idFuncionario = idFuncionario;
            this.nome = nome;
            this.salario = salario;
            this.dataAdmissao = dataAdmissao;
        }

        public Funcionario()
        {

        }

        public int IdFuncionario { get => idFuncionario; set => idFuncionario = value; }
        public string Nome { get => nome; set => nome = value; }
        public decimal Salario { get => salario; set => salario = value; }
        public DateTime DataAdmissao { get => dataAdmissao; set => dataAdmissao = value; }
    }
}
