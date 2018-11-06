using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrartexto
{
    class Regra
    {
        private string Switch_on { get; set; }
        private string Inicio { get; set; }
        private string Fim { get; set; }
        private bool JaFoi { get; set; }
        public void FiltrarLinhas(string pesquisa)            
        {
            Console.WriteLine("Digite o nome do arquivo:");
            String Arquivo = Console.ReadLine();
            string[] textLines = File.ReadAllLines(Arquivo);
            List<string> results = new List<string>();
            Console.WriteLine("Deseja remover alguma informação da string? S/N");
            string deseja = Console.ReadLine();
            foreach (string linha in textLines)
            {
                if (linha.Contains(pesquisa))
                {
                    if (deseja == "S" || deseja == "s")
                    {
                        string ade = RemoverInformacao(linha);
                        results.Add(ade);
                    }
                    else
                    {
                        Console.WriteLine(linha);
                        results.Add(linha);
                    }
                }
            }
            TextWriter tw = new StreamWriter("Saida.log");

            foreach (string s in results)
            {
                tw.WriteLine(s);
            }

            tw.Close();
        }
        private string RemoverInformacao(string texto)
        {
            string resultado = texto;
            int pFrom, pTo;
            while (Switch_on != "1" && Switch_on != "2" && Switch_on != "3")
                {
                    Console.Clear();
                    Console.WriteLine(" Escolha as opções");
                    Console.WriteLine("1 - Filtrar texto entre a string");
                    Console.WriteLine("2 - Filtrar texto do fim da string");
                    Console.WriteLine("3 - Filtrar texto do início da string");
                    Console.WriteLine("#####################################");
                    Switch_on = Console.ReadLine();
                    if (Switch_on != "1" && Switch_on != "2" && Switch_on != "3")
                    {
                    Console.WriteLine("Caractere inválido!");
                    }
                }

            switch (Switch_on)
            {
                case "1":
                    {
                        if (!JaFoi)
                        {
                            Console.Clear();
                            Console.WriteLine("Input:");
                            Console.WriteLine(texto);
                            Console.WriteLine("Digite de onde a String irá começar");
                            Inicio = Console.ReadLine();
                            Console.WriteLine("Digite de onde a String irá acabar");
                            Fim = Console.ReadLine();
                            JaFoi = true;
                        }
                        pFrom = texto.IndexOf(Inicio) + Inicio.Length;
                        pTo = texto.LastIndexOf(Fim);
                        resultado = texto.Substring(pFrom, pTo - pFrom);
                        Console.WriteLine("Resultado = " + resultado);
                        break;
                    }
                case "2":
                    {
                        if (!JaFoi)
                        {
                            Console.Clear();
                            Console.WriteLine("Input:");
                            Console.WriteLine(texto);
                            Console.WriteLine("Digite de onde irá acabar a String");
                            Fim = Console.ReadLine();
                            JaFoi = true;
                        }
                        pTo = texto.LastIndexOf(Fim);
                        resultado = texto.Substring(0, pTo);
                        Console.WriteLine("Resultado = " + resultado);
                        break;
                    }
                case "3":
                    {
                        if (!JaFoi)
                        {
                            Console.Clear();
                            Console.WriteLine("Input:");
                            Console.WriteLine(texto);
                            Console.WriteLine("Digite de onde o texto irá começar");
                            Inicio = Console.ReadLine();
                            JaFoi = true;
                        }
                        pFrom = texto.IndexOf(Inicio) + Inicio.Length;
                        resultado = texto.Substring(pFrom);
                        Console.WriteLine("Resultado = " + resultado);
                        break;
                    }
            }
            return resultado;
        }       
    }
}
