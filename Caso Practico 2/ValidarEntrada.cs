using System;

public class ValidarEntrada
{
    // Método nuevo para obligar a que el texto no esté vacío
    public static string ObtenerTexto(string mensaje)
    {
        Console.WriteLine(mensaje);
        string entrada = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("El nombre no puede estar vacío. Inténtalo de nuevo:");
            entrada = Console.ReadLine();
        }
        return entrada;
    }

    public static int ObtenerNumero(string mensaje)
    {
        Console.WriteLine(mensaje);
        string entrada = Console.ReadLine();

        int numeroLimpio;
        while (!int.TryParse(entrada, out numeroLimpio) || numeroLimpio < 0)
        {
            Console.WriteLine("Entrada inválida. Por favor, introduce un número entero positivo.");
            entrada = Console.ReadLine();
        }
        return numeroLimpio;
    }

    public static string ObtenerFecha()
    {
        Console.WriteLine("Introduce la fecha (formato dd-mm-yy) o escribe 'hoy':");
        string entrada = Console.ReadLine();

        if (entrada.ToLower() == "hoy")
        {
            return DateTime.Now.ToString("dd-MM-yy");
        }

        DateTime fechaLimpia;
        while (!DateTime.TryParseExact(entrada, "dd-MM-yy", new System.Globalization.CultureInfo("es-ES"), System.Globalization.DateTimeStyles.None, out fechaLimpia))
        {
            Console.WriteLine("Fecha inválida. Usa el formato dd-mm-yy o escribe 'hoy':");
            entrada = Console.ReadLine();
        }

        return entrada;
    }
}