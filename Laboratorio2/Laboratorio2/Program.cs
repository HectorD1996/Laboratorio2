using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Llaves llave = new Llaves();
            //llave.getKeys();
            llave.getKeys();

            string path, comandos;
            Console.Write("RSA>> ");
            comandos = Console.ReadLine();
            bool error = false;
            comandos.Trim();
            if (comandos.StartsWith("-c "))
            {
                comandos = comandos.Substring(3, comandos.Length - 3);
                comandos.Trim();
                if (comandos.StartsWith("-f "))
                {
                    comandos = comandos.Substring(3, comandos.Length - 3);
                    comandos.Trim();
                    path = comandos;
                    llave.Encripta(path);
                }
                else
                {
                    Console.WriteLine("RSA>> Error");
                }
            }
            else if (comandos.StartsWith("-d "))
            {
                comandos = comandos.Substring(3, comandos.Length - 3);
                comandos.Trim();
                if (comandos.StartsWith("-f "))
                {
                    comandos = comandos.Substring(3, comandos.Length - 3);
                    comandos.Trim();
                    path = comandos;
                    llave.desencripta(path);
                }
                else
                {
                    Console.WriteLine("RSA>> Error");
                }
            }
            else
            {
                Console.WriteLine("RSA>> Error");
                error = true;
            }
        }
    }
}
