using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Primos lISTpRIMOS = new Primos();
            lISTpRIMOS.LeerPrimos();
            Llaves llave = new Llaves();
            //llave.getKeys();
            llave.getKeys(lISTpRIMOS);

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
                   
                    comandos = comandos.Replace('"', ' ');//se quitan las comillas dobles
                    
                    path = comandos.Trim(); ;

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
                    comandos = comandos.Replace('"', ' ');//se quitan las comillas dobles
                    path = comandos;
                    Console.WriteLine("Ingrese LLave public n y d");
                    
                    
                    BigInteger n = BigInteger.Parse(Console.ReadLine());
                    BigInteger d = BigInteger.Parse(Console.ReadLine());
                    
                    llave.desencripta(path, d , n);
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
            Console.ReadKey();
        }
    }
}
