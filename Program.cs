using System;

interface IRestaurable
{
    void Restaurar();
}

interface IProtegible
{
    void Cubrirse();
}

abstract class UnidadCombate
{
    public string Alias { get; protected set; }
    public int Energia { get; private set; }
    public int Rango { get; protected set; }

    public UnidadCombate(string alias, int energia, int rango)
    {
        Alias = alias;

        if (energia < 1)
        {
            Energia = 1;
        }
        else if (energia > 100)
        {
            Energia = 100;
        }
        else
        {
            Energia = energia;
        }

        if (rango < 1)
        {
            Rango = 1;
        }
        else
        {
            Rango = rango;
        }
    }

    public void MostrarInfo()
    {
        Console.WriteLine("Alias: " + Alias);
        Console.WriteLine("Energía: " + Energia);
        Console.WriteLine("Rango: " + Rango);
        Console.WriteLine();
    }

    public abstract void EjecutarAccion();

    public void RecibirImpacto(int cantidad)
    {
        if (cantidad < 0)
        {
            cantidad = 0;
        }

        Energia = Energia - cantidad;

        if (Energia < 0)
        {
            Energia = 0;
        }

        Console.WriteLine(Alias + " recibe " + cantidad + " puntos de daño.");
        Console.WriteLine("Energía restante: " + Energia);

        if (Energia == 0)
        {
            Console.WriteLine(Alias + " ha sido destruido.");
        }

        Console.WriteLine();
    }

    protected void AumentarEnergia(int cantidad)
    {
        Energia = Energia + cantidad;

        if (Energia > 100)
        {
            Energia = 100;
        }
    }
}