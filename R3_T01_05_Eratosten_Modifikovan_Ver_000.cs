using System;
// using System.Diagnostics;

class R3_T01_05_Eratosten_Modifikovan_Ver_000
{
    static long[] Eratosten_Niz_Napuni_INT_Ver_01(long n)   // Prosti brojevi do N. Za N, odnosno broj B = 0,1,2,3,4,5,6,7,8,9,10:
    {                                                       // MODIFIKOVANO Eratostenovo sito              0,1,2,3,2,5,2,7,2,3,2    // Pamcenje najmanjeg delioca svakog broja
        long[] Prost_niz_INT = new long[n + 1];
        for (long B = 0; B <= n; B++) Prost_niz_INT[B] = B; // Nakon ove linije koda niz ce biti:          0,1,2,3,4,5,6,7,8,9,10
        for (long B = 2; B * B <= n; B++)                   // Vrednost B ide od 2 do SQRT(n) => ako je n=10 b ce ici od 2 do 3, jer je vec 4*4 > 10
            if (Prost_niz_INT[B] == B)                      // Kada je B=2, Prost_niz_INT[2] == 2 TRUE, za B=3 isto, ali vec za B=4 bice FALSE, jer ce Prost_niz_INT[4]=2
                for (long k = B * B; k <= n; k = k + B)     // Kada je B=2, k krece od 2*2, tj od 4 i 
                    if (Prost_niz_INT[k] == k)              // posto je prvi put Prost_niz_INT[4]==4 TRUE onda
                        Prost_niz_INT[k] = B;               // Prost_niz_INT[4] dobija vrednost 2 => Prost_niz_INT[4]=2, u sledecem prolazu Prost_niz_INT[6] takodje dobija 2...
        return Prost_niz_INT;                               // U ovoj liniji koda niz je:                  0,1,2,3,2,5,2,7,2,3,2    // Pamcenje najmanjeg delioca svakog broja
    }
    static bool[] Eratosten_Niz_Napuni_BOOL_Ver_00(long n)  // Prosti brojevi do N. Za N, odnosno broj B = 0,1,2,3,4,5,6,7,8,9,10:
    {                                                       // Eratostenovo sito                           F,F,T,T,F,T,F,T,F,F,F 
        bool[] Prost_niz_BOOL = new bool[n + 1];
        for (long B = 0; B <= n; B++) Prost_niz_BOOL[B] = true;     // Moze da se dodatno malo ubrza, tako sto ce se izbaciti ova for petlja
        Prost_niz_BOOL[0] = false; Prost_niz_BOOL[1] = false;       // u tom slucaju inicijalne vrednosti su FALSE, pa treba okrenuti TF i da se zove Slozen_niz_BOOL
        for (long B = 2; B * B <= n; B++)                   // Vrednost B ide od 2 do SQRT(n) => ako je n=10 b ce ici od 2 do 3, jer je vec 4*4 > 10
            if (Prost_niz_BOOL[B])                          // Kada je B=2, Prost_niz_BOOL[2]=TRUE, za B=3 isto, ali vec za B=4 bice FALSE, jer ce Prost_niz_BOOL[4]=FALSE
                for (long k = B * B; k <= n; k = k + B)     // Kada je B=2, k krece od 2*2, tj od 4 i 
                    Prost_niz_BOOL[k] = false;              // Prost_niz_INT[4] dobija vrednost FALSE => Prost_niz_INT[4]=F, u sledecem prolazu Prost_niz_INT[6] takodje dobija F...
        return Prost_niz_BOOL;                              // U ovoj liniji koda niz je:                  F,F,T,T,F,T,F,T,F,F,F
    }
    static void Main()
    {
        // Zad_00_Eratosten();
        // Zad_01_Zbir_prostih_prost();
        long n = 10;
        long[] Prost_niz_INT = Eratosten_Niz_Napuni_INT_Ver_01(n);
        for (long b = 1; b <= n; b++) Console.Write(Prost_niz_INT[b] + " ");
    }
    static void Zad_00_Eratosten()
    {
        long a = long.Parse(Console.ReadLine());  // interval [a, b] 1 <= a <= b <= 10^7  --> 1
        long b = long.Parse(Console.ReadLine());  // interval [a, b] 1 <= a <= b <= 10^7  --> 1000000007 nekoliko sekundi
        long s = 0;  // Zbir svih prostih brojeva u intervalu [a, b]
        long p = 0;  // Broj svih prostih brojeva u intervalu [a, b]
        // Stopwatch t = new Stopwatch();
        // t.Start();
        Prosti_brojevi_u_intervalu_A_B_Ver_01(a, b, ref p, ref s); Console.WriteLine(p + " " + s);  // O(N * Log Log (N) = N * (1/2+1/3+1/5+1/7+1/11+...)
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        // t.Start();
        // Prosti_brojevi_u_longervalu_A_B_Ver_00(a, b, ref p, ref s); Console.WriteLine(p + " " + s);  // O(N*Sqrt(N))
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
    }

    static void Zad_01_Zbir_prostih_prost()
    {
        long n = long.Parse(Console.ReadLine());
        bool[] Prost_niz_BOOL = Eratosten_Niz_Napuni_BOOL_Ver_00(n);
        int brojParova = 0;
        int p = 2;
        for (int q = p + 1; p + q <= n; q++)
            if (Prost_niz_BOOL[q] && Prost_niz_BOOL[p + q])
                brojParova++;
        Console.WriteLine(brojParova);
    }

    const long MOD = 1000000;                // Ako zbir ima vise od 6 cifara ispisati samo ostatak pri deljenju sa 1000000
    static void Prosti_brojevi_u_intervalu_A_B_Ver_01(long a, long b, ref long p, ref long s)
    {
        s = 0;  // Zbir svih prostih brojeva u longervalu [a, b]
        p = 0;  // Broj svih prostih brojeva u longervalu [a, b]
        // Stopwatch t = new Stopwatch(); t.Start();
        bool[] Prost_niz_BOOL = Eratosten_Niz_Napuni_BOOL_Ver_00(b);
        // t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();      // oko 12 sec za b = 1000000007 (vrednost a nema uticaja moze biti 1 ili 1000000007)
        for (long x = a; x <= b; x++)
            if (Prost_niz_BOOL[x]) { p++; s = s + x; s = s % MOD; }
    }


}

// n = 1000000007;              // n = 10^9 + 7
// n = 1111111111111111111;     // n > 10^19

/*
    static bool Prost_Ver_04_Brzi(long n)          // O(Sqrt(N)) 
    {
        if (n == 1 || (n % 2 == 0 && n > 2) || (n % 3 == 0 && n > 3)) return false;
        for (long k = 1; (6 * k - 1) * (6 * k - 1) <= n; k++)
            if (n % (6 * k - 1) == 0 || n % (6 * k + 1) == 0) return false;
        return true;
    }

    static void Prosti_brojevi_u_longervalu_A_B_Ver_00(long a, long b, ref long p, ref long s)
    {
        s = 0;  // Zbir svih prostih brojeva u longervalu [a, b]
        p = 0;  // Broj svih prostih brojeva u longervalu [a, b]
        for (long x = a; x <= b; x++)
            if (Prost_Ver_04_Brzi(x)) { p++; s = s + x; s = s % MOD; }
    }
  
 
 
 
 
 */








// Kurs: R2_T02_Sleozenost_03_Odsecanje_Eratosten: https://petlja.org/sr-Latn-RS/kurs/17838/2/3504
// Kurs: R3_T01_Algebarski_algoritmi_05_Eratosten: https://petlja.org/sr-Latn-RS/kurs/17918/1/5325
// Kurs: R3_T01_Algebarski_algoritmi_05_Eratosten: https://petlja.org/sr-Latn-RS/kurs/17918/1/5323#id4 Pamcenje najmanjeg delioca svakog broja
// Zbirka stara: https://petlja.org/sr-Latn-RS/biblioteka/r/problemi/Zbirka-stara/eratostenovo_sito
// Zbirka 2: https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/eratostenovo_sito
// Zbirka 3: https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/eratostenovo_sito
// Vikipedija GIF: https://upload.wikimedia.org/wikipedia/commons/b/b9/Sieve_of_Eratosthenes_animation.gif
// Vikipedija: https://sr.wikipedia.org/wiki/%D0%95%D1%80%D0%B0%D1%82%D0%BE%D1%81%D1%82%D0%B5%D0%BD%D0%BE%D0%B2%D0%BE_%D1%81%D0%B8%D1%82%D0%BE
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija-bilijar#tab_133477
// https://arena.petlja.org/sr-Latn-RS/competition/r3-t01-05-faktorizacija#tab_133477 
// https://www.petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/zbir_prostih_prost
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/zbir_prostih_prost
// https://www.petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/broj_prostih_u_intervalima
