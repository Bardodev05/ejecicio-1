/*  Nombre del estudiante:Anderson Molina Fieroo
 Grupo:213022_353
 Número y texto del programa.:Pareja de Problemas Problema 1: 1

 Código Fuente: autoría propia.
 Breve Explicación del uso de la/las función(es) utilizada.:CalcularEdadPromedio(int[] edades): Esta función recibe un arreglo de edades y calcula el promedio de dichas edades. Retorna el valor del promedio como un número de tipo double.

EncontrarEdadesCercanas(int[] edades, double promedio): Esta función recibe un arreglo de edades y el valor del promedio. Encuentra las dos edades más cercanas al promedio y las retorna en un arreglo de dos elementos.

ObtenerNombresCercanos(string[] nombres, int[] edades, int[] edadesCercanas): Esta función recibe un arreglo de nombres, un arreglo de edades y un arreglo con las dos edades más cercanas al promedio. Encuentra los nombres de los empleados que tienen esas edades y los retorna en un arreglo de dos elementos
 */
using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedir el nombre del usuario
        Console.Write("Ingrese su nombre: ");
        string nombreUsuario = Console.ReadLine();

        // Pedir la cantidad de empleados a valorar
        Console.Write("Ingrese la cantidad de empleados a valorar: ");
        int cantidadEmpleados = int.Parse(Console.ReadLine());

        // Crear arreglos para almacenar nombres y edades de empleados
        string[] nombres = new string[cantidadEmpleados];
        int[] edades = new int[cantidadEmpleados];

        // Pedir nombres y edades de los empleados
        for (int i = 0; i < cantidadEmpleados; i++)
        {
            Console.Write("Ingrese el nombre del empleado {0}: ", i + 1);
            nombres[i] = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado {0}: ", i + 1);
            edades[i] = int.Parse(Console.ReadLine());
        }

        // Calcular la edad promedio de los empleados
        double edadPromedio = CalcularEdadPromedio(edades);

        // Encontrar las dos edades más cercanas al promedio
        int[] edadesCercanas = EncontrarEdadesCercanas(edades, edadPromedio);

        // Encontrar los nombres de los empleados con las edades más cercanas al promedio
        string[] nombresCercanos = ObtenerNombresCercanos(nombres, edades, edadesCercanas);

        // Mostrar resultados por pantalla
        Console.WriteLine("La edad promedio de los empleados es: {0}", edadPromedio);
        Console.WriteLine("Los empleados con las edades más cercanas al promedio son:");
        for (int i = 0; i < edadesCercanas.Length; i++)
        {
            Console.WriteLine("- {0} con edad {1}", nombresCercanos[i], edadesCercanas[i]);
        }

        // Agradecer al usuario por usar el programa
        Console.WriteLine("Gracias por usar el programa, {0}!", nombreUsuario);
    }

    static double CalcularEdadPromedio(int[] edades)
    {
        // Calcular la suma de las edades
        int sumaEdades = 0;
        for (int i = 0; i < edades.Length; i++)
        {
            sumaEdades += edades[i];
        }

        // Calcular la edad promedio
        double edadPromedio = (double)sumaEdades / edades.Length;

        return edadPromedio;
    }

    static int[] EncontrarEdadesCercanas(int[] edades, double edadPromedio)
    {
        // Encontrar las dos edades más cercanas al promedio
        int[] edadesCercanas = new int[2];
        double diferencia1 = double.MaxValue;
        double diferencia2 = double.MaxValue;

        for (int i = 0; i < edades.Length; i++)
        {
            double diferenciaActual = Math.Abs(edadPromedio - edades[i]);

            if (diferenciaActual < diferencia1)
            {
                diferencia2 = diferencia1;
                diferencia1 = diferenciaActual;
                edadesCercanas[1] = edadesCercanas[0];
                edadesCercanas[0] = edades[i];
            }
            else if (diferenciaActual < diferencia2)
            {
                diferencia2 = diferenciaActual;
                edadesCercanas[1] = edades[i];
            }
        }

        return edadesCercanas;
    }

    static string[] ObtenerNombresCercanos(string[] nombres, int[] edades, int[] edadesCercanas)
    {
        // Encontrar los nombres de los empleados con las edades más cercanas al promedio
        string[] nombresCercanos = new string[2];

        for (int i = 0; i < edades.Length; i++)
        {
            if (edades[i] == edadesCercanas[0])
            {
                nombresCercanos[0] = nombres[i];
            }
            else if (edades[i] == edadesCercanas[1])
            {
                nombresCercanos[1] = nombres[i];
            }
        }

        return nombresCercanos;
    }
}
