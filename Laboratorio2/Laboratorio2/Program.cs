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
            Primos lISTpRIMOS = new Primos();
            lISTpRIMOS.LeerPrimos();
            Llaves llave = new Llaves();
            llave.getKeys(lISTpRIMOS);
        }
    }
}
