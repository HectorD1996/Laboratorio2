
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace Laboratorio2
{
   
    public class Primos
    {
        StreamReader Pr = new StreamReader("Primos.txt");
        List<BigInteger> PrimosCargados = new List<BigInteger>();

        public void LeerPrimos()
        {
            string[] stringSeparators = new string[] { "   " };
            
            while (Pr.Peek() != -1)
            {
                string TempPrimos = Pr.ReadLine();
                if (TempPrimos != "")
                {
                    String[] ListPrimos = TempPrimos.Trim().Split(stringSeparators, StringSplitOptions.None);
                    foreach (var Primo in ListPrimos)
                    {
                        PrimosCargados.Add(BigInteger.Parse(Primo));
                    }
                }
                
            }

            String end = "";
        }
       
        public BigInteger DarPrimo()
        {
            Random rngesus = new Random();
            

            return PrimosCargados[rngesus.Next(PrimosCargados.Count -1)];
        }
    }
}
