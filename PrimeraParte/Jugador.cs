using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraParte
{
    internal class Jugador
    {
       
        public int Puntaje { get; set; }

        public Jugador(string nombre)
        {
           
            Puntaje = 0;
        }

        public void LanzarDado(Dado dado)
        {
            int resultado = dado.Lanzar();
            Puntaje += resultado;
            Console.WriteLine($" haz lanzado un {resultado}. Puntuación actual: {Puntaje}");
        }
    }
}
