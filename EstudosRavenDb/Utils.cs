using System;

namespace EstudosRavenDb
{
    public static class Utils
    {
        public static int PedirNumeroParaUsuario(string texto)
        {
            Console.WriteLine(texto);
            var eInvalido = !int.TryParse(Console.ReadLine(), out var valorDigitado);

            if (eInvalido)
            {
                Console.WriteLine("Numero digitado inválido\n");
                return -1;
            }
                

            return valorDigitado;
        }

    }
}