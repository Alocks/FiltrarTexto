using System;
using System.Collections.Generic;
using System.IO;

namespace filtrartexto
{
    class FiltrarTexto
    {
        private string Switch_on;
        private string Inicio;
        private string Fim;
        private bool JaFoi;
        public FiltrarTexto()
        {
            Console.WriteLine("Digite as linhas que contenham X palavra ou texto, para trazer retorno");
            FiltrarLinhas(Console.ReadLine());
            Console.WriteLine("Terminado com sucesso!");
            Console.ReadKey();
        }
        private void FiltrarLinhas(string pesquisa)            
        {
             bool feito = false;
            string[] LinhasTexto = null;
        while (!feito)
        {
                try
                {
                    Console.WriteLine("Digite o nome do arquivo:");
                    String Arquivo = Console.ReadLine();
                    LinhasTexto = File.ReadAllLines(Arquivo);
                    feito = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Nome do Arquivo inválido! Tente novamente.");
                }
        }
            bool Ainda = false;
            string deseja = "";
                List<string> results = new List<string>();


            foreach (string linha in LinhasTexto)
            {
                if (linha.Contains(pesquisa))
                {
                    if (!Ainda)
                    {
                        Console.Clear();
                        Console.WriteLine("Input do que foi retornado:");
                        Console.WriteLine(linha);
                        Console.WriteLine("Deseja remover alguma informação da string? S/N");
                        deseja = Console.ReadLine();
                        Ainda = true;
                    }
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
                Console.WriteLine("Input:");
                Console.WriteLine(texto);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Escolha as opções:");
                Console.WriteLine("1 - Filtrar texto entre a string");
                Console.WriteLine("2 - Filtrar texto do fim da string");
                Console.WriteLine("3 - Filtrar texto do início da string");
                Switch_on = Console.ReadLine();
                Console.Clear();
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
