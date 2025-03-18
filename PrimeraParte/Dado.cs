using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraParte
{
    public class Dado
    {
        private Random random;

        public Dado()
        {
            random = new Random();
        }

        public int Lanzar()
        {
            return random.Next(1, 7); // Número aleatorio entre 1 y 6
        }
    }
}
