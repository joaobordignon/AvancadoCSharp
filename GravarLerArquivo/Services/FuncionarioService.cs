using GravarLerArquivo.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GravarLerArquivo.Services
{
    public class FuncionarioService
    {
        string path = "D:\\DotNet\\AvancadoCSharp\\CursoAvancadoCSharp\\GravarLerArquivo\\Persistencia\\";


        public void ExportarTXT(Funcionario funcionario)
        {
            using (StreamWriter streamWriter = new StreamWriter(path + "funcionario.txt", true))
            {
                streamWriter.WriteLine("Cód:" + funcionario.IdFuncionario);
                streamWriter.WriteLine();
                streamWriter.WriteLine($"Nome: {funcionario.Nome}");
                streamWriter.WriteLine();
                streamWriter.WriteLine($"Salario: {funcionario.Salario}");
                streamWriter.WriteLine();
                streamWriter.WriteLine($"Data de Admissao: {funcionario.DataAdmissao}");
                streamWriter.WriteLine("\n");
            }
        }

        public void ExportarJSON(Funcionario funcionario)
        {
            List<Funcionario> jsonData = LerArquivoJson();
            jsonData.Add(funcionario);
            using (StreamWriter writer = new StreamWriter(path+"funcionario.json"))
            {
                string dados = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
                writer.WriteLine(dados);
            }
        }

        public void ExportarParaXml(Funcionario funcionario)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement root = new XElement("funcionarios");
            XElement child = new XElement("funcionario");
            child.Add(new XElement("idFuncionario", funcionario.IdFuncionario));
            child.Add(new XElement("nome", funcionario.Nome));
            child.Add(new XElement("salario", funcionario.Salario));
            child.Add(new XElement("dataAdmissao", funcionario.DataAdmissao));
            root.Add(child);
            if (File.Exists(path + "funcionario.xml"))
            {
                doc = XDocument.Load(path + "funcionario.xml");
                var result = doc.Descendants("funcionarios");
                result.Last().Add(child);
            }
            else
            {
                doc.Add(root);
            }
            doc.Save(path + "funcionario.xml");
        }

        public string LerArquivoTXT()
        {
            using (StreamReader sr = new StreamReader(path + "funcionario.txt"))
            {
                string content = sr.ReadToEnd();
                return content;
            }
        }

        public List<Funcionario> LerArquivoJson() 
        {
            using (StreamReader sw = new StreamReader(path + "funcionario.json"))
            {
                string json = sw.ReadToEnd();
                List<Funcionario> funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(json);
                return funcionarios;
            }
        }

        public List<Funcionario> LerArquivoXml()
        {
            XDocument xdoc = XDocument.Load(path + "funcionario.xml");
            var result = from q in xdoc.Descendants("funcionario")
                         select new
                         {
                             IdFuncionario = q.Element("idFuncionario").Value,
                             Nome = q.Element("nome").Value,
                             Salario = q.Element("salario").Value,
                             DataAdmissao = q.Element("dataAdmissao").Value
                         };
            List<Funcionario> list = new List<Funcionario>();
            foreach (var f in result)
            {
                Funcionario func = new Funcionario(
                int.Parse(f.IdFuncionario),
                f.Nome,
                decimal.Parse(f.Salario),
                DateTime.Parse(f.DataAdmissao));
                list.Add(func);
            }
            return list;
        }


    }

}