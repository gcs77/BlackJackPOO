using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraParte
{
    public class Maquina
    {
        public int Puntaje { get; set; }

        public Maquina()
        {
            Puntaje = 0;
        }

        public void JugarTurno(Dado dado)
        {
            while (Puntaje <= 16)
            {
                int resultado = dado.Lanzar();
                Puntaje += resultado;
                Console.WriteLine($"La máquina ha lanzado un {resultado}. Puntuación actual: {Puntaje}");
            }
        }



    }
}
