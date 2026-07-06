public class SimuladorTarifa
{
    public static void Main(string[] args)
    {
        
     Console.WriteLine("========================================");
        Console.WriteLine("       InDrive - Cierre de Turno");
        Console.WriteLine("========================================\n");

        int cantidadViajes;

        Console.Write("Ingrese la cantidad de viajes realizados en el día: ");
        cantidadViajes = int.Parse(Console.ReadLine());

        while (cantidadViajes <= 0)
        {
            Console.WriteLine("\nError: La cantidad de viajes debe ser mayor a 0.");
            Console.Write("Ingrese nuevamente la cantidad de viajes: ");
            cantidadViajes = int.Parse(Console.ReadLine());
        }

        double[] tarifas = new double[cantidadViajes];
        bool[] picoHora = new bool[cantidadViajes];

        for (int i = 0; i < cantidadViajes; i++)
        {
            double distancia;
            int hora;
            int tipoVehiculo;

            do
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("Registro del viaje N° " + (i + 1));
                Console.WriteLine("----------------------------------------");

                Console.Write("Distancia del viaje (km): ");
                distancia = double.Parse(Console.ReadLine());

                Console.Write("Hora de salida (0 - 23): ");
                hora = int.Parse(Console.ReadLine());

                Console.WriteLine("\nTipo de vehículo:");
                Console.WriteLine("  1. Económico");
                Console.WriteLine("  2. Confort");
                Console.WriteLine("  3. Premium");
                Console.WriteLine("  4. Moto");
                Console.Write("Seleccione opción: ");
                tipoVehiculo = int.Parse(Console.ReadLine());

                if (!EsValido(distancia, hora, tipoVehiculo))
                {
                    Console.WriteLine("\nDatos inválidos. Verifique:");
                    Console.WriteLine("- La distancia debe ser mayor a 0.");
                    Console.WriteLine("- La hora debe estar entre 0 y 23.");
                    Console.WriteLine("- El tipo de vehículo debe estar entre 1 y 4.");
                    Console.WriteLine("Vuelva a ingresar los datos del viaje.");
                }

            } while (!EsValido(distancia, hora, tipoVehiculo));

            tarifas[i] = CalcularTarifa(distancia, hora, tipoVehiculo);
            picoHora[i] = EsHoraPico(hora);

            Console.WriteLine("\nTarifa calculada del viaje N° " + (i + 1) + ": S/ " + tarifas[i]);
        }

        double total = CalcularTotal(tarifas);
        double promedio = CalcularPromedio(tarifas);
        double maximo = EncontrarMaximo(tarifas);
        double minimo = EncontrarMinimo(tarifas);
        int viajesHoraPico = ContarHoraPico(picoHora);

        Console.WriteLine("\n========================================");
        Console.WriteLine("          RESUMEN CIERRE DE TURNO");
        Console.WriteLine("========================================");
        Console.WriteLine("Número de viajes realizados : " + cantidadViajes);
        Console.WriteLine("Total ganado                : S/ " + total);
        Console.WriteLine("Tarifa promedio             : S/ " + promedio);
        Console.WriteLine("Viaje más rentable          : S/ " + maximo);
        Console.WriteLine("Viaje más económico         : S/ " + minimo);
        Console.WriteLine("Viajes en hora pico         : " + viajesHoraPico);
        Console.WriteLine("========================================");
    }

    static bool EsHoraPico(int hora)
    {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
    }

    static bool EsValido(double distancia, int hora, int tipoVehiculo)
    {
        return distancia > 0 && hora >= 0 && hora <= 23 && tipoVehiculo >= 1 && tipoVehiculo <= 4;
    }

    static double CalcularTarifa(double distancia, int hora, int tipoVehiculo)
    {
        double tarifaBase = 0;
        double costoKm = 0;

        switch (tipoVehiculo)
        {
            case 1:
                tarifaBase = 2.00;
                costoKm = 1.50;
                break;

            case 2:
                tarifaBase = 3.00;
                costoKm = 2.00;
                break;

            case 3:
                tarifaBase = 5.00;
                costoKm = 3.00;
                break;

            case 4:
                tarifaBase = 1.50;
                costoKm = 1.00;
                break;
        }

        double subtotal = tarifaBase + (costoKm * distancia);

        if (EsHoraPico(hora))
        {
            subtotal = subtotal * 1.30;
        }

        if (distancia > 15)
        {
            double descuento = subtotal * 0.05;
            subtotal = subtotal - descuento;
        }

        double tarifaFinal = Math.Max(subtotal, 5.00);
        tarifaFinal = Math.Round(tarifaFinal, 2);

        return tarifaFinal;
    }

    static double CalcularTotal(double[] tarifas)
    {
        double total = 0;

        for (int i = 0; i < tarifas.Length; i++)
        {
            total = total + tarifas[i];
        }

        return Math.Round(total, 2);
    }

    static double CalcularPromedio(double[] tarifas)
    {
        double total = CalcularTotal(tarifas);
        double promedio = total / tarifas.Length;

        return Math.Round(promedio, 2);
    }

    static double EncontrarMaximo(double[] tarifas)
    {
        double maximo = tarifas[0];

        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] > maximo)
            {
                maximo = tarifas[i];
            }
        }

        return maximo;
    }

    static double EncontrarMinimo(double[] tarifas)
    {
        double minimo = tarifas[0];

        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] < minimo)
            {
                minimo = tarifas[i];
            }
        }

        return minimo;
    }

    static int ContarHoraPico(bool[] picoHora)
    {
        int contador = 0;

        for (int i = 0; i < picoHora.Length; i++)
        {
            if (picoHora[i])
            {
                contador++;
            }
        }

        return contador;
    }
}