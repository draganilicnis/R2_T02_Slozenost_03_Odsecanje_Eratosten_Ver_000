using System;
// using System.Diagnostics;

class R2_T02_Slozenost_03_Odsecanje_Eratosten_Ver_000
{
    const long MOD = 1000000;                // Ako zbir ima vise od 6 cifara ispisati samo ostatak pri deljenju sa 1000000
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());  // interval [a, b] 1 <= a <= b <= 10^7  --> 1
        long b = long.Parse(Console.ReadLine());  // interval [a, b] 1 <= a <= b <= 10^7  --> 1000000007 nekoliko sekundi
        long s = 0;  // Zbir svih prostih brojeva u intervalu [a, b]
        long p = 0;  // Broj svih prostih brojeva u intervalu [a, b]

        // Stopwatch t = new Stopwatch();
        // t.Start();
        // Prosti_brojevi_u_longervalu_A_B_Ver_00(a, b, ref p, ref s); Console.WriteLine(p + " " + s);  // O(N*Sqrt(N))
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        // t.Start();
        Prosti_brojevi_u_intervalu_A_B_Ver_01(a, b, ref p, ref s); Console.WriteLine(p + " " + s);  // O(N * Log Log (N) = N * (1/2+1/3+1/5+1/7+1/11+...)
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
    }

    static bool[] Eratosten_Niz_Napuni(long n)         // ProstiBrojeviDo N
    {
        bool[] Prost_niz = new bool[n + 1];
        for (long i = 0; i <= n; i++) Prost_niz[i] = true;

        Prost_niz[0] = false; Prost_niz[1] = false;
        for (long b = 2; b * b <= n; b++)
            if (Prost_niz[b])
                for (long k = b * b; k <= n; k = k + b) Prost_niz[k] = false;
        return Prost_niz;
    }
    static void Prosti_brojevi_u_intervalu_A_B_Ver_01(long a, long b, ref long p, ref long s)
    {
        s = 0;  // Zbir svih prostih brojeva u longervalu [a, b]
        p = 0;  // Broj svih prostih brojeva u longervalu [a, b]
        // Stopwatch t = new Stopwatch(); t.Start();
        bool[] Prost_niz = Eratosten_Niz_Napuni(b);
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();      // oko 12 sec za b = 1000000007 (vrednost a nema uticaja moze biti 1 ili 1000000007)
        for (long x = a; x <= b; x++)
            if (Prost_niz[x]) { p++; s = s + x; s = s % MOD; }
    }

    static void Prosti_brojevi_u_longervalu_A_B_Ver_00(long a, long b, ref long p, ref long s)
    {
        s = 0;  // Zbir svih prostih brojeva u longervalu [a, b]
        p = 0;  // Broj svih prostih brojeva u longervalu [a, b]
        for (long x = a; x <= b; x++)
            if (Prost_Ver_04_Brzi(x)) { p++; s = s + x; s = s % MOD; }
    }
    static bool Prost_Ver_04_Brzi(long n)          // O(Sqrt(N)) 
    {
        if (n == 1 || (n % 2 == 0 && n > 2) || (n % 3 == 0 && n > 3)) return false;
        for (long k = 1; (6 * k - 1) * (6 * k - 1) <= n; k++)
            if (n % (6 * k - 1) == 0 || n % (6 * k + 1) == 0) return false;
        return true;
    }
}

// n = 1000000007;              // n = 10^9 + 7
// n = 1111111111111111111;     // n > 10^19



// Kurs: R2_T02_Sleozenost_03_Odsecanje_Eratosten: https://petlja.org/sr-Latn-RS/kurs/17838/2/3504
// Kurs: R3_T01_Algebarski_algoritmi_05_Eratosten: https://petlja.org/sr-Latn-RS/kurs/17918/1/5325
// Zbirka stara: https://petlja.org/sr-Latn-RS/biblioteka/r/problemi/Zbirka-stara/eratostenovo_sito
// Zbirka 2: https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/eratostenovo_sito
// Zbirka 3: https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/eratostenovo_sito
// Vikipedija GIF: https://upload.wikimedia.org/wikipedia/commons/b/b9/Sieve_of_Eratosthenes_animation.gif
// Vikipedija: https://sr.wikipedia.org/wiki/%D0%95%D1%80%D0%B0%D1%82%D0%BE%D1%81%D1%82%D0%B5%D0%BD%D0%BE%D0%B2%D0%BE_%D1%81%D0%B8%D1%82%D0%BE
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija-bilijar#tab_133477
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija#tab_133477 
