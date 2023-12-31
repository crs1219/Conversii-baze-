using System;

class Conversii
{
    static void Main(string[] args)
    {
        Console.WriteLine("Conversii din baza b1 in baza b2 a unor numere in virgula fixa. Bazele b1 si b2 sunt intre 2 si 16.");

        Console.WriteLine("Introduceti baza b1: ");
        int b1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduceti baza b2: ");
        int b2 = Convert.ToInt32(Console.ReadLine());

        if (b1 < 2 || b1 > 16 || b2 < 2 || b2 > 16)
        {
            Console.WriteLine("Bazele introduse trebuie sa fie intre intre 2 si 16.");
            return;
        }

        Console.WriteLine("Introduceti numarul in virgula fixa in baza initiala: ");
        var nrInitial = Console.ReadLine();

        if (!IsDecimal(nrInitial, b1))
        {
            Console.WriteLine("Numarul nu este in virgula fixa.");
        }

        int nrFinal = Conversie(Convert.ToInt32(nrInitial), b1, b2);

        Console.WriteLine("Numarul in virgula fixa in baza finala este: " + nrFinal);

        Console.ReadKey();
    }

    static bool IsDecimal(string nrInitial, int b1)
    {
        return decimal.TryParse(nrInitial, out _);
    }

    static int Conversie(int nrInitial, int b1, int b2)
    {
        int nrFinal = 0;
        int putere = 1;

        while (nrInitial != 0)
        {
            int cifra = nrInitial % 10;
            nrInitial /= 10;

            nrFinal += cifra * putere;
            putere *= b1;
        }

        nrInitial = nrFinal;
        nrFinal = 0;
        putere = 1;

        while (nrInitial != 0)
        {
            int cifra = nrInitial % b2;
            nrInitial /= b2;

            nrFinal += cifra * putere;
            putere *= 10;
        }

        return nrFinal;
    }
}