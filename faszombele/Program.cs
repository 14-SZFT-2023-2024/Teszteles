using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = BeolvasFuvarokat("fuvar.csv");

            Console.WriteLine($"1. feladat: {fuvarok.Count} fuvar");
            var taxi6185 = fuvarok.Where(x => x.Azonosito == 6185);
            Console.WriteLine($"2. feladat: {taxi6185.Count()} fuvar alatt: {taxi6185.Sum(x => x.Viteldij):C2}");

            Console.WriteLine("3. feladat:");
            FuvarokatFizetesiModokSzerintSzamolEsKiir(fuvarok);

            Console.WriteLine($"4. feladat: {fuvarok.Sum(x => x.Tavolsag * 1.6):F2} km");

            var leghosszabbFuvar = fuvarok.OrderByDescending(x => x.Idotartam).First();
            Console.WriteLine($"5. feladat: Leghosszabb fuvar:\n\r\ tFuvar hossza: {leghosszabbFuvar.Idotartam} másodperc\n\r\tTaxi azonosító: {leghosszabbFuvar.Azonosito}\n\r\tMegtett távolság: {leghosszabbFuvar.Tavolsag * 1.6:F1} km\n\r\tViteldíj: {leghosszabbFuvar.Viteldij:C2}");

            HibaAdatokKiirasa("hibak.txt", fuvarok.Where(x => x.Idotartam > 0 && x.Viteldij > 0 && x.Tavolsag == 0).OrderBy(x => x.Indulas));

            Console.WriteLine("6. feladat az alábbi file-ba található meg: hibak.txt");
            Console.ReadKey();
        }

        static List<Fuvar> BeolvasFuvarokat(string fajlnev)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();
            using (StreamReader fajl = new StreamReader(fajlnev, Encoding.UTF8))
            {
                fajl.ReadLine();
                while (!fajl.EndOfStream)
                {
                    fuvarok.Add(new Fuvar(fajl.ReadLine()));
                }
            }
            return fuvarok;
        }

        static void FuvarokatFizetesiModokSzerintSzamolEsKiir(List<Fuvar> fuvarok)
        {
            fuvarok.GroupBy(x => x.Fizetesmod)
                   .Select(y => new { Fizetesimod = y.Key, Fuvarszam = y.Count() })
                   .ToList()
                   .ForEach(z => Console.WriteLine($"\t{z.Fizetesimod}: {z.Fuvarszam} fuvar"));
        }

        static void HibaAdatokKiirasa(string fajlnev, IEnumerable<Fuvar> hibasFuvarok)
        {
            using (StreamWriter fajl = new StreamWriter(fajlnev, false, Encoding.UTF8))
            {
                fajl.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                hibasFuvarok.ToList().ForEach(y => fajl.WriteLine($"{y.Azonosito};{y.Indulas:yyyy-MM-dd HH:mm:ss};{y.Idotartam};{y.Tavolsag};{y.Viteldij};{y.Borravalo};{y.Fizetesmod}"));
            }
        }

        class Fuvar
        {
            public int Azonosito { get; private set; }
            public DateTime Indulas { get; private set; }
            public int Idotartam { get; private set; }
            public double Tavolsag { get; private set; }
            public double Viteldij { get; private set; }
            public double Borravalo { get; private set; }
            public string Fizetesmod { get; private set; }

            public Fuvar(string adatsor)
            {
                string[] adatok = adatsor.Split(';');
                Azonosito = int.Parse(adatok[0].Trim());
                Indulas = DateTime.Parse(adatok[1].Trim());
                Idotartam = int.Parse(adatok[2].Trim());
                Tavolsag = double.Parse(adatok[3].Trim());
                Viteldij = double.Parse(adatok[4].Trim());
                Borravalo = double.Parse(adatok[5].Trim());
                Fizetesmod = adatok[6].Trim();
            }
        }
    }
}
