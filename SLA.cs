public class SLA
{
    public static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("     Calcule los Acuerdos de Nivel de Servicio (SLA)  ");
        Console.WriteLine("========================================");

      
         DateTime fechaCreacion, fechaResolucion;
        DateTime actual;
        int horasLaborales = 0;

        // Lista para guardar el detalle por día
        List<string> detalle = new List<string>();

        // Entrada
        Console.Write("Fecha de creación (yyyy-MM-dd HH:mm): ");
        fechaCreacion = DateTime.Parse(Console.ReadLine());

        Console.Write("Fecha de resolución (yyyy-MM-dd HH:mm): ");
        fechaResolucion = DateTime.Parse(Console.ReadLine());

        if (fechaResolucion <= fechaCreacion)
        {
            Console.WriteLine("La fecha de resolución debe ser mayor que la fecha de creación.");
            return;
        }

        actual = fechaCreacion;

     
        while (actual.Date <= fechaResolucion.Date)
        {
            // Excluir fines de semana
            if (actual.DayOfWeek != DayOfWeek.Saturday &&
                actual.DayOfWeek != DayOfWeek.Sunday)
            {
                DateTime inicio = actual.Date.AddHours(9);
                DateTime fin = actual.Date.AddHours(17);

                if (actual.Date == fechaCreacion.Date && fechaCreacion > inicio)
                    inicio = fechaCreacion;

                if (actual.Date == fechaResolucion.Date && fechaResolucion < fin)
                    fin = fechaResolucion;

                if (fin > inicio)
                {
                    int horas = (int)(fin - inicio).TotalHours;

                    if (horas > 0)
                    {
                        horasLaborales += horas;
                        detalle.Add(horas + "h el " + actual.ToString("dddd"));
                    }
                }
            }

            actual = actual.Date.AddDays(1);
        }

      
        Console.WriteLine();
        Console.WriteLine("========================================");

        if (horasLaborales <= 8)
        {
            Console.Write("Cumplido (Horas laborales: ");

            for (int i = 0; i < detalle.Count; i++)
            {
                Console.Write(detalle[i]);

                if (i < detalle.Count - 1)
                    Console.Write(" + ");
            }

            Console.WriteLine(" = " + horasLaborales + "h).");
        }
        else
        {
            Console.Write("▪	Excedido: " + (horasLaborales - 8) + " horas de más (Horas laborales: ");

            for (int i = 0; i < detalle.Count; i++)
            {
                Console.Write(detalle[i]);

                if (i < detalle.Count - 1)
                    Console.Write(" + ");
            }

            Console.WriteLine(" = " + horasLaborales + "h).");
        }

        Console.WriteLine("========================================");
    }
}