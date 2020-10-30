using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravarLerArquivo.Input
{
    public class FuncionarioInput
    {
        public static int LerIdFuncionario()
        {
            Console.Write("Informe o ID do Funcionário........: ");
            return int.Parse(Console.ReadLine());
        }
        public static string LerNome()
        {
            Console.Write("Informe o Nome do Funcionário......: ");
            return Console.ReadLine();
        }
        public static decimal LerSalario()
        {
            Console.Write("Informe o Salário do Funcionário...: ");
            return decimal.Parse(Console.ReadLine());
        }
        public static DateTime LerDataAdmissao()
        {
            Console.Write("Informe a Data de Admissão.........: ");
            return DateTime.Parse(Console.ReadLine());
        }

    }
}

