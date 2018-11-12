using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace filtrartexto
{
    class FiltrarTexto
    {
        private string Arquivo;
        private int opcao;
        private string Inicio;
        private string Fim;
        private bool JaFoi;
        public FiltrarTexto()
        {
            FiltrarLinhas();
            Console.WriteLine("Terminado com sucesso!");
            Console.ReadKey();
        }
        private void FiltrarLinhas()            
        {
            bool feito = false;
            bool Ainda = false;
            List<string> resultado = new List<string>();
            string[] LinhasTexto = null;
            string deseja = "";
            string pesquisa = "";


        while (!feito)
        {
                try
                {
                    Console.WriteLine("Digite o nome do arquivo:");
                    Arquivo = Console.ReadLine();
                    LinhasTexto = File.ReadAllLines(Arquivo);
                    Console.Clear();
                    Console.WriteLine("Consultando as primeiras 20 linhas do arquivo\n\n");
                    for (int i=0; i<20;i++)
                    {
                        Console.WriteLine(LinhasTexto[i]);
                    }
                    Console.WriteLine("\n\nDigite as linhas que contenham X palavra ou texto, para trazer retorno");
                    pesquisa = Console.ReadLine();
                    pesquisa = pesquisa.ToUpper();
                    if (string.IsNullOrEmpty(pesquisa))
                        throw new ArgumentException("Favor, digitar algo.");
                        feito = true;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
        }

            foreach (string linha in LinhasTexto)
            {
                string linhaCaps = linha.ToUpper();
                if (linhaCaps.Contains(pesquisa))
                {
                    while (!Ainda)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Input do que foi retornado:");
                            Console.WriteLine(linha);
                            Console.WriteLine("Deseja remover alguma informação da string? S/N");
                            deseja = Console.ReadLine();
                            if (deseja.ToUpper() != "N" && deseja.ToUpper() != "S")
                                throw new ArgumentException("Opção inválida!");
                            else Ainda = true;
                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Thread.Sleep(1500);
                        }
                    }
                    if (deseja.ToUpper() == "S")
                    {
                        string ade = RemoverInformacao(linha);
                        resultado.Add(ade);
                    }
                    else
                    {
                        Console.WriteLine(linha);
                        resultado.Add(linha);
                    }
                }
            }
            TextWriter tw = new StreamWriter("Saida.log");
            foreach (string s in resultado)
            {
                tw.WriteLine(s);
            }
            tw.Close();
        }

        private string RemoverInformacao(string texto)
        {
            string resultado = texto;
            int de, para;
            while (opcao != 1 && opcao != 2 && opcao != 3)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Input:");
                    Console.WriteLine(texto);
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(" Escolha as opções:");
                    Console.WriteLine("1 - Filtrar texto entre a string");
                    Console.WriteLine("2 - Filtrar texto do fim da string");
                    Console.WriteLine("3 - Filtrar texto do início da string");
                    opcao = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(3000);
                }
            }
            switch (opcao)
            {
                case 1:
                    {
                        if (!JaFoi)
                        {
                            RemoverOpcao(true, true, texto);
                            JaFoi = true;
                        }
                        de = texto.IndexOf(Inicio) + Inicio.Length;
                        para = texto.LastIndexOf(Fim);
                        resultado = texto.Substring(de, para - de);
                        break;
                    }
                case 2:
                    {
                        if (!JaFoi)
                        {
                            RemoverOpcao(false, true, texto);
                            JaFoi = true;
                        }
                        para = texto.LastIndexOf(Fim);
                        resultado = texto.Substring(0, para);
                        break;
                    }
                case 3:
                    {
                        if (!JaFoi)
                        {
                            RemoverOpcao(true, false, texto);
                            JaFoi = true;
                        }
                        de = texto.IndexOf(Inicio) + Inicio.Length;
                        resultado = texto.Substring(de);
                        break;
                    }
            }
            Console.WriteLine("Resultado = " + resultado);
            return resultado;
        }  



        private void RemoverOpcao(bool inicio, bool fim, string texto)
        {
            Console.Clear();
            Console.WriteLine("Input:");
            Console.WriteLine(texto);

            if (inicio)
            {
                Console.WriteLine("Digite de onde a String irá começar (Case Sensitive)");
                Inicio = Console.ReadLine();
                
            }
            if(fim)
            {
                Console.WriteLine("Digite de onde a String irá acabar (Case Sensitive)");
                Fim = Console.ReadLine();
            }


        }
    }
}
