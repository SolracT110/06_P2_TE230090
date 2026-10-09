Console.WriteLine("06_SISTEMA de Inspeccion de Lote");
Console.WriteLine();

// Clases: InspeccionLote
// Objetos: inspeccion
// Propiedades: picor y pidef
// Metodos: regisp, Calporco y estLo

InspeccionLote inspeccion = new InspeccionLote();

// Registra el ciclo de 10 piezas
for (int i = 1; i <= 10; i++)
{
    bool entradaValida = false;

    while (!entradaValida)
    {
        Console.WriteLine("RECUERDE QUE (1 = Correcta, 0 = Defectuosa)");
        Console.Write($"Pieza {i} - Ingrese estado: ");
        if (int.TryParse(Console.ReadLine(), out int lect))
        {
            if (inspeccion.regisp(lect))
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("ERROR: Valor no reconocido. Ingrese únicamente 1 o 0.");
            }
        }
        else
        {
            Console.WriteLine("ERROR: Entrada no válida. Ingrese únicamente 1 o 0.");
        }
    }
}

// Solicitar a los objetos los resultados de los calculos ´
double porcentaje = inspeccion.Calporco();
string estadoFinal = inspeccion.estLo();


// Mostrar resultados
Console.WriteLine();
Console.WriteLine($"Piezas correctas: {inspeccion.picor}");
Console.WriteLine($"Piezas defectuosas: {inspeccion.pidef}");
Console.WriteLine();
Console.WriteLine($"Porcentaje de calidad: {porcentaje:F2} %");
Console.WriteLine($"Estado final del lote: {estadoFinal}");


// Clases
class InspeccionLote
{
    // Propiedades
    public int picor { get; set; }

    public int pidef { get; set; }

    // Aqui se gurda los valores de las piezas 
    public InspeccionLote()
    {
        picor = 0;
        pidef = 0;
    }



    // Método para registrar cada pieza
    public bool regisp(int lect)
    {
        if (lect == 1)
        {
            picor++;
            return true;
        }
        else if (lect == 0)
        {
            pidef++;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Aqui se calcula el porcentaje de piezas buenas del lote
    public double Calporco()
    {
        double porcentaje;

        porcentaje = ((double)picor / 10.0) * 100.0;

        return porcentaje;
    }



    // Aqui se calcula si el lote es bueno o malo
    public string estLo()
    {
        double porcentaje = Calporco();

        if (porcentaje >= 90.0)
        {
            return "ACEPTADO";
        }
        else
        {
            return "RECHAZADO";
        }
    }
}