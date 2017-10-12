using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;//Se usa referencia a System Numeric para poder usar Big Integer
using System.IO;


namespace Laboratorio2
{
    public class Llaves
    {
        
        //primos
        BigInteger p = 0;
        BigInteger q = 0;
        BigInteger n;

        // Φ (simbolo)
        BigInteger fi;
        BigInteger e;
        BigInteger d;
        public void getKeys()
        {
          
            p = 1511;
            q = 1709;
           
            n = p * q;

            //Calcular Φ (n)=(p-1)*(q-1)
            fi = (p - 1) * (q - 1);
            e = 0;
            d = 0;

            //Encontrar el numero Comprimo de Φ praband Multiples valores hasta encontralo
            for (int i = 2; i < fi; i++)
            {
                if (relativelyPrime(i,fi))
                {
                    e = i;
                    break;
                }
            }

            //Enontrar d por medio de metodo Modo Inverse
            d = ModInverse(e, fi);


            
        }

        //Deteterminar numeros coprimos
        private BigInteger gcd(BigInteger a, BigInteger b)
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

        private bool relativelyPrime(BigInteger a, BigInteger b)
        {
            return gcd(a, b) == 1;
        }

        //Funcion ModInv encunetre al muodular inverso de d, de e y Φ
        public BigInteger ModInverse(BigInteger a, BigInteger b)
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

        public BigInteger[] Encripta(String mensaje)
        {
            
            int i;
            byte[] temp = new byte[1];
            //byte[] digitos = File.ReadAllBytes(mensaje);
            byte[] digitos = pasarByte(mensaje);
            BigInteger[] bigdigitos = new BigInteger[digitos.Length];

            for (i = 0; i < bigdigitos.Length; i++)
            {
                temp[0] = digitos[i];
                bigdigitos[i] = new BigInteger(temp);
            }
            BigInteger[] encriptado = new BigInteger[bigdigitos.Length];
            for (i = 0; i < bigdigitos.Length; i++)
            {
                //BigInter.ModPow( 'number', 'exponent', 'modulus'));
                encriptado[i] = BigInteger.ModPow(bigdigitos[i], e, n);
            }
            return encriptado;
        }
        private byte[] pasarByte(string mensaje)
        {
            char[] aux = mensaje.ToCharArray();
            byte[] digitos = new byte[aux.Length];
            for (int j = 0; j < aux.Length; j++)
            {
                digitos[j] = Convert.ToByte(aux[j]);
            }
            return digitos;
        }

        public string desencripta(BigInteger[] encriptado)
        {
            BigInteger[] desencriptado = new BigInteger[encriptado.Length];
            for (int i = 0; i < desencriptado.Length; i++)
            {
                //BigInter.ModPow( 'number', 'exponent', 'modulus'));
                desencriptado[i] = BigInteger.ModPow(encriptado[i], d, n);
            }
            char[] charArray = new char[desencriptado.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = (char)desencriptado[i];
            }
            return (new string(charArray));
        }


    }
}
