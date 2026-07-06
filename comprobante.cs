
public class Comprobante
{
    static bool ValidarComprobanteElectronico(string numero)
    {

        if (string.IsNullOrEmpty(numero))
            return false;

   
        if (numero.Length != 13)
            return false;

      
        if (numero[4] != '-')
            return false;

      
        if (numero[0] != 'B' && numero[0] != 'F')
            return false;

      
        for (int i = 1; i <= 3; i++)
        {
            if (!char.IsDigit(numero[i]))
                return false;
        }

        for (int i = 5; i < 13; i++)
        {
            if (!char.IsDigit(numero[i]))
                return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(" Validación de Comprobante Electrónico");
        Console.WriteLine("========================================");

        string numero;
        bool valido;

        Console.Write("Ingrese el comprobante: ");
        numero = Console.ReadLine();

        valido = ValidarComprobanteElectronico(numero);

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Comprobante: " + numero);

        if (valido)
        {
            Console.WriteLine("Estado: VÁLIDO");
        }
        else
        {
            Console.WriteLine("Estado: INVÁLIDO");
        }

        Console.WriteLine("========================================");
    }
}