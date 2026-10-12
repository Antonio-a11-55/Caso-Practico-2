using System;

class Program
{
    static void Main(string[] args)
    {
        ConexionBD bd = new ConexionBD();

        try
        {
            bd.CrearTabla();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al iniciar la base de datos: {ex.Message}");
            return;
        }

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- REGISTRO DE HÁBITOS ---");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("1 - Ver todos los registros");
            Console.WriteLine("2 - Insertar registro");
            Console.WriteLine("3 - Borrar registro");
            Console.WriteLine("4 - Actualizar registro");
            Console.WriteLine("------------------------------------------");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "0":
                    salir = true;
                    break;
                case "1":
                    try { 
                    bd.VerTodos();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer la base de datos: {ex.Message}");
                    }

                    break;
                case "2":
                    MenuInsertar(bd);
                    break;
                case "3":
                    MenuBorrar(bd);
                    break;
                case "4":
                    MenuActualizar(bd);
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Escribe un número del 0 al 4.");
                    break;
            }
        }
    }

    static void MenuInsertar(ConexionBD bd)
    {
        string nombre = ValidarEntrada.ObtenerTexto("¿Cuál es el nombre del hábito que quieres registrar?: ");
        string fecha = ValidarEntrada.ObtenerFecha();
        int cantidad = ValidarEntrada.ObtenerNumero("¿qué cantidad quieres registrar?");

        try
        {
            bd.Insertar(nombre, fecha, cantidad);
            Console.WriteLine("\n¡Registro guardado con éxito!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al insertar en la base de datos: {ex.Message}");
        }
    }

    static void MenuBorrar(ConexionBD bd)
    {
        Console.WriteLine("--- BORRAR REGISTRO ---");

        try
        {
            bd.VerTodos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer la base de datos: {ex.Message}");
            return;
        }
            
        int id = ValidarEntrada.ObtenerNumero("Introduce el ID del registro que quieres borrar, o escribe 0 para cancelar: ");

        if (id != 0)
        {

            try
            {
                bd.Borrar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar borrar en la base de datos: {ex.Message}");
            }

        }
    }

    static void MenuActualizar(ConexionBD bd)
    {
        Console.WriteLine("--- ACTUALIZAR REGISTRO ---");

        try
        {
            bd.VerTodos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al leer la base de datos: {ex.Message}");
            return;
        }

        int id = ValidarEntrada.ObtenerNumero("Introduce el ID del registro que quieres actualizar, o escribe 0 para cancelar: ");

        if (id != 0)
        {
            string nuevoNombre = ValidarEntrada.ObtenerTexto("Introduce el nuevo nombre del hábito: ");
            string nuevaFecha = ValidarEntrada.ObtenerFecha();
            int nuevaCantidad = ValidarEntrada.ObtenerNumero("Introduce la nueva cantidad: ");

                try
                {
                    bd.Actualizar(id, nuevoNombre, nuevaFecha, nuevaCantidad);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nOcurrió un error al intentar actualizar la base de datos: {ex.Message}");
                }

            }
    }
}