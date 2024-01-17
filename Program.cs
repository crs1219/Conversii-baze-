using System;

class Conversii
{
    static void Main(string[] args)
    {
        Console.WriteLine("Conversii din baza b1 in baza b2 a unor numere in virgula fixa. Bazele b1 si b2 sunt intre 2 si 16.");

        // preluare date
        Console.WriteLine("Introduceti baza b1: ");
        int b1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduceti baza b2: ");
        int b2 = Convert.ToInt32(Console.ReadLine());

        if (b1 < 2 || b1 > 16 || b2 < 2 || b2 > 16)   // verificare date
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

    // verifica daca numarul este in virgula fixa
    static bool IsDecimal(string nrInitial, int b1)
    {
        return decimal.TryParse(nrInitial, out _);
    }

    // conversie din baza b1 in baza b2
    static int Conversie(int nrInitial, int b1, int b2)
    {
        int nrFinal = 0;   // numarul in baza finala
        int putere = 1;    // puterea bazei b2

        while (nrInitial != 0)   // conversie din baza b1 in baza 10
        {
            int cifra = nrInitial % 10;   // ultima cifra a numarului
            nrInitial /= 10;           // eliminarea ultimei cifre

            nrFinal += cifra * putere;   // adaugarea ultimei cifre la numarul final
            putere *= b1;             // cresterea puterii bazei b2
        }

        nrInitial = nrFinal;   // numarul in baza 10
        nrFinal = 0;        // numarul in baza finala
        putere = 1;      // puterea bazei b2

        while (nrInitial != 0)   // conversie din baza 10 in baza b2
        {
            int cifra = nrInitial % b2;   // ultima cifra a numarului
            nrInitial /= b2;       // eliminarea ultimei cifre

            nrFinal += cifra * putere;   // adaugarea ultimei cifre la numarul final
            putere *= 10;          // cresterea puterii bazei b2
        }

        return nrFinal;
    }
}