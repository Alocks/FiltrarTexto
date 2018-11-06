using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace filtrartexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Regra a = new Regra();
            bool feito = false;
            while (!feito)
            {
                try
                {
                    Console.WriteLine("Digite as linhas que contenham X palavra ou texto, para trazer retorno");
                    a.FiltrarLinhas(Console.ReadLine());
                    feito = true;
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Nome do Arquivo inválido! Tente novamente.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

            Console.WriteLine("Aperte qualquer tecla para finalizar o programa...");
            Console.ReadKey();
        }
    }
}
