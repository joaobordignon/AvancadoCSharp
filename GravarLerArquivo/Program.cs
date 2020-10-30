using GravarLerArquivo.Entities;
using GravarLerArquivo.Input;
using GravarLerArquivo.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravarLerArquivo
{
    class Program
    {
        static void Main(string[] args)


        {
           /// string path = "D:\\DotNet\\AvancadoCSharp\\CursoAvancadoCSharp\\GravarLerArquivo\\Persistencia\\";
           Console.WriteLine("***CADASTRO DE FUNCIONARIOS***");
            Funcionario f1 = new Funcionario();
            
            FuncionarioService fs = new FuncionarioService();

            //JObject o1 = JObject.Parse(File.ReadAllText(path+ "funcionario.json"));



            try
            {
                 f1.IdFuncionario = FuncionarioInput.LerIdFuncionario();
                 f1.Nome = FuncionarioInput.LerNome();
                 f1.DataAdmissao = FuncionarioInput.LerDataAdmissao();
                 f1.Salario = FuncionarioInput.LerSalario();
                //  fs.ExportarTXT(f1);
                 fs.ExportarJSON(f1);
                //Console.WriteLine(fs.LerArquivoTXT());

               // List<Funcionario> lista = fs.LerArquivoJson();

               // foreach(Funcionario f in lista)
              //  {
              //      Console.WriteLine(f.Nome);
              //  }


                

                // read JSON directly from a file
                /*string st = File.ReadAllText(path + "funcionario.json");
                Console.WriteLine(st);*/
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: "+ e.Message);
               
            }
            
            

            Console.ReadKey();
            
        }
    }
}
