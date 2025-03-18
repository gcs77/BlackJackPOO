using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraParte
{
    
    
    public class Juego
    {
       
        public void inicio()
        {

            Juego jugarSolo = new Juego();
            Juego jugarConAmigos = new Juego();



            Console.WriteLine("¡Bienvenido al Blackjack con dados!");
            Console.WriteLine("Selecciona el modo de juego:");
            Console.WriteLine("1. Jugar solo (contra la maquina)");
            Console.WriteLine("2. Jugar con amigos (todos contra la maquina)");
            int modoJuego = int.Parse(Console.ReadLine());

            if (modoJuego == 1)
            {
                jugarSolo.JugarSolo();
            }
            else if (modoJuego == 2)
            {
                jugarConAmigos.JugarConAmigos();
            }
            else
            {
                Console.WriteLine("Opción no valida. Saliendo del juego...");
            }
            Console.ReadKey();
        }
        
        private Dado dado;

        public Juego()
        {
            dado = new Dado();
        }



        public void JugarSolo()
        {

            
            Console.WriteLine("\nModo: Jugar solo (contra la máquina)");

            Jugador jugador = new Jugador("Jugador 1");
            Maquina maquina = new Maquina();

            // Turno del jugador
            jugador.LanzarDado(dado);
            jugador.LanzarDado(dado);


           

            // Opción de pedir otro dado
            while (true)
            {
                Console.WriteLine("¿Quieres pedir otro dado? (s/n)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "s")
                {
                    jugador.LanzarDado(dado);


                    if (jugador.Puntaje > 21)
                    {
                        Console.WriteLine("Te has pasado de 21. ¡Has perdido!");
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            // Turno de la máquina
           
            Console.WriteLine("\nTurno de la maquina...");
            while (maquina.Puntaje <= 16)
            {
                Console.WriteLine("\nTurno de la máquina...");
                maquina.JugarTurno(dado);

                // Determinar el resultado
                DeterminarResultado(jugador.Puntaje, maquina.Puntaje);
            }

           
        }

        public void JugarConAmigos()
        {
            Random rand = new Random();
            List<int> puntajesJugadores = new List<int>();

            Console.WriteLine("\nModo: Jugar con amigos (todos contra la maquina)");
            Console.WriteLine("¿Cuántos amigos van a jugar (ademas de usted)?");
            int numAmigos = int.Parse(Console.ReadLine());
            int numJugadores = numAmigos + 1; // Usted mas sus amigos

            // Todos los jugadores reciben su puntuación inicial
            for (int i = 0; i < numJugadores; i++)
            {
                int dado1 = rand.Next(1, 7);
                int dado2 = rand.Next(1, 7);
                int puntajeInicial = dado1 + dado2;

                Console.WriteLine($"\nJugador {i + 1} ha lanzado {dado1} y {dado2}. Puntuacion inicial: {puntajeInicial}.");
                puntajesJugadores.Add(puntajeInicial);
            }

            // Cada jugador puede pedir otro dado
            for (int i = 0; i < numJugadores; i++)
            {
                Console.WriteLine($"\nTurno del Jugador {i + 1} para pedir otro dado:");
                while (true)
                {
                    Console.WriteLine($"Jugador {i + 1}, tu puntuacion actual es {puntajesJugadores[i]}.");
                    Console.WriteLine("¿Quieres pedir otro dado? (s/n)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "s")
                    {
                        int dado = rand.Next(1, 7);
                        puntajesJugadores[i] += dado;
                        Console.WriteLine($"Has lanzado un {dado}. Tu nueva puntuacion es {puntajesJugadores[i]}.");

                        if (puntajesJugadores[i] > 21)
                        {
                            Console.WriteLine("Te has pasado de 21. ¡Pierdes este turno!");
                            puntajesJugadores[i] = 0; // El jugador pierde automáticamente
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // La máquina juega contra cada jugador individualmente
            for (int i = 0; i < numJugadores; i++)
            {
                Console.WriteLine($"\nTurno de la maquina contra el Jugador {i + 1}:");

                int puntajeMaquina = 0;
                while (puntajeMaquina <= 16)
                {
                    int dado = rand.Next(1, 7);
                    puntajeMaquina += dado;
                    Console.WriteLine($"La maquina ha lanzado un {dado}. Su puntuación total es {puntajeMaquina}.");
                }

                int puntajeJugador = puntajesJugadores[i];

                if (puntajeMaquina > 21)
                {
                    Console.WriteLine("La mquina se ha pasado de 21. ¡El Jugador {i + 1} gana!");
                }
                else if (puntajeJugador > 21)
                {
                    Console.WriteLine("El Jugador {i + 1} se ha pasado de 21. ¡La maquina gana!");
                }
                else if (puntajeJugador > puntajeMaquina)
                {
                    Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Maquina: {puntajeMaquina} puntos. ¡El Jugador {i + 1} gana!");
                }
                else if (puntajeJugador == puntajeMaquina)
                {
                    Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Maquina: {puntajeMaquina} puntos. ¡Es un empate!");
                }
                else
                {
                    Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Maquina: {puntajeMaquina} puntos. ¡La maquina gana!");
                }
            }

           
            Console.ReadKey();

            
        }
        
        
        
        
        
        public void DeterminarResultado(int puntajeJugador, int puntajeMaquina)
        {
            if (puntajeMaquina > 21)
            {
                Console.WriteLine("La maquina se ha pasado de 21. ¡Has ganado!");
            }
            else if (puntajeJugador > puntajeMaquina)
            {
                Console.WriteLine($"Tu puntuacion: {puntajeJugador}. Puntuacion de la maquina: {puntajeMaquina}. ¡Has ganado!");
            }
            else if (puntajeJugador == puntajeMaquina)
            {
                Console.WriteLine($"Tu puntuacion: {puntajeJugador}. Puntuacion de la maquina: {puntajeMaquina}. ¡Es un empate!");
            }
            else
            {
                Console.WriteLine($"Tu puntuacion: {puntajeJugador}. Puntuación de la maquina: {puntajeMaquina}. ¡Has perdido!");
            }
        }

    }

}

