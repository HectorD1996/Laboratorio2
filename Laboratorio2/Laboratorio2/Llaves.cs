using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;//Se usa referencia a System Numeric para poder usar Big Integer


namespace Laboratorio2
{
    public class Llaves
    {
        public static void getKeys()
        {
            //Primos

            BigInteger p = 771154151515621;
            BigInteger q = 15151851841949;
            BigInteger n = p * q;

            //Calcular Φ (n)=(p-1)*(q-1)
            BigInteger fi = (p - 1) * (q - 1);
            BigInteger e = 0;
            BigInteger  d = 0;

            //Encontrar el numero Comprimo de Φ praband Multiples valores hasta encontralo
            for (int i = 2; i < fi; i++)
            {
                if (relativelyPrime(i,fi))
                {
                    e = i;
                    break;
                }
            }

            //Enontrar d
            d = ModInverse(e, fi);


            string test ="";
        }

        //Deteterminar numeros coprimos
        private static BigInteger gcd(BigInteger a, BigInteger b)
        {
            BigInteger t;
            while (b != 0)
            {
                t = a;
                a = b;
                b = t % b;
            }
            return a;
        }

        private static bool relativelyPrime(BigInteger a, BigInteger b)
        {
            return gcd(a, b) == 1;
        }

        //Funcion ModInv encunetre al muodular inverso de d, de e y Φ
        public static BigInteger ModInverse(BigInteger a, BigInteger b)
        {
            BigInteger b0 = b, t, q;
            BigInteger x0 = 0, x1 = 1;
            if (b == 1) return 1;
            while (a > 1)
            {
                q = a / b;
                t = b;
                b = a % b; 
                a = t;
                t = x0;
                x0 = x1 - q * x0; 
                x1 = t;
            }
            if (x1 < 0) x1 += b0;
            return x1;
        }


        

    }
}
