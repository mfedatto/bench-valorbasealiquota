using System.Diagnostics;

namespace ValorBaseAliquota;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch timerTotal = new();
        Stopwatch timerOperacao = new();
        
        timerTotal.Start();

        IEnumerable<double> salarios = Salarios();
        int quantidade = salarios.Count();
        
        timerOperacao.Start();
        
        double total = CalcularPorAliquota(salarios, 8d);
        
        timerOperacao.Stop();
        
        Console.WriteLine($"Tempo de execução para {quantidade} salários: {timerOperacao.ElapsedMilliseconds} milissegundos.");

        timerTotal.Stop();
        
        Console.WriteLine($"Tempo total de execução: {timerTotal.ElapsedMilliseconds} milissegundos.");
    }

    static IEnumerable<double> Salarios()
    {
        for (int i = 0; i < 100_000_000; i++)
            yield return i / 100d;
    }

    static double CalcularPorAliquota(IEnumerable<double> salarios, double aliquota)
    {
        double total = 0d;
        
        foreach (double salario in salarios)
            total += salario * (aliquota / 100d);

        return total;
    }
}
