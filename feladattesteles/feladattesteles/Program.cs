using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace feladattesteles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("fuvar.csv");

            List<Fuvar> fuvarList = new List<Fuvar>();

            for (int i = 1; i < lines.Length; i++)
            {
                Fuvar fuvarinstance = new Fuvar(lines[i]);

                fuvarList.Add(fuvarinstance);
            }

            Console.WriteLine("3. feladat");
            UtakSzama(fuvarList);

            Console.WriteLine("4. feladat");
            BevEsUtazas(fuvarList);

            Console.WriteLine("5. feladat");
            FizetesiModStatisztika(fuvarList);

            Console.WriteLine("6. feladat");
            OsszKm(fuvarList);

            Console.WriteLine("7. feladat");
            LeghosszabbUt(fuvarList);

            Hibak(fuvarList);

            Console.ReadKey();
        }

        private static void Hibak(List<Fuvar> fuvarlist)
        {
            List<string> hibalista = new List<string>();

            fuvarlist = fuvarlist.OrderBy(i => i.indulas).ToList();

            foreach (var fuvar in fuvarlist)
            {
                if (fuvar.viteldij > 0 && fuvar.idotartam > 0 && fuvar.tavolsag == 0)
                {
                    hibalista.Add(fuvar.taxiId + ";" + fuvar.indulas + ";" + fuvar.idotartam + ";" + fuvar.tavolsag + ";" + fuvar.viteldij + ";" + fuvar.borravalo + ";" + fuvar.fizetes_modja);
                }
            }

            //FileStream fileStream = new FileStream("C:/Users/gluck/source/repos/Fuvar/hibak.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter("hibak.txt", false);

            sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");

            for (int i = 0; i < hibalista.Count; i++)
            {
                sw.WriteLine("{0};", hibalista[i].ToString());
            }

            sw.Close();
        }


        private static void LeghosszabbUt(List<Fuvar> fuvarList)
        {
            double leghosszabbuttav = 0;
            int leghosszabbutido = 0;
            int leghosszabbuttaxiId = 0;
            double leghosszabbutveteldij = 0;

            foreach (var fuvar in fuvarList)
            {
                if (fuvar.idotartam >= leghosszabbuttav)
                {
                    leghosszabbuttav = fuvar.tavolsag;
                    leghosszabbutido = fuvar.idotartam;
                    leghosszabbuttaxiId = fuvar.taxiId;
                    leghosszabbutveteldij = fuvar.viteldij;
                }
            }
            Console.WriteLine("A leghosszabb fuvar:");
            Console.WriteLine("Fuvar hossza: " + leghosszabbutido);
            Console.WriteLine("Taxi azonosító: " + leghosszabbuttaxiId);
            Console.WriteLine("Megtett távolság: " + leghosszabbuttav + " mérföld, " + string.Format("{0:0.00}", leghosszabbuttav * 1.6) + " km");
            Console.WriteLine("Viteldíj: " + leghosszabbutveteldij);
        }

        private static void OsszKm(List<Fuvar> fuvarList)
        {
            double osszKm = 0;

            foreach (var fuvar in fuvarList)
            {
                osszKm += fuvar.tavolsag * 1.6;
            }
            Console.WriteLine(String.Format("{0:0.00}", osszKm));
        }

        private static void FizetesiModStatisztika(List<Fuvar> fuvarList)
        {
            List<string> fizetesimod = new List<string>();
            List<string> fizetesimodelv = new List<string>();

            foreach (var fuvar in fuvarList)
            {
                fizetesimod.Add(Convert.ToString(fuvar.fizetes_modja));
            }

            fizetesimodelv = fizetesimod.Distinct().ToList();
            int z = 0;

            for (int i = 0; i < fizetesimodelv.Count; i++)
            {
                z = 0;

                for (int j = 0; j < fuvarList.Count; j++)
                {
                    if (fizetesimodelv[i] == fuvarList[j].fizetes_modja)
                    {
                        z++;
                    }
                }
                Console.WriteLine(fizetesimodelv[i] + ": " + z + " fuvar");
                ;
            }
        }

        private static void BevEsUtazas(List<Fuvar> fuvarList)
        {
            double bevetel = 0;
            int utazasszama = 0;

            foreach (var fuvar in fuvarList)
            {
                if (fuvar.taxiId == 6185)
                {
                    //bevetel += fuvar.viteldij + fuvar.borravalo;
                    bevetel += fuvar.viteldij;
                    utazasszama++;
                }
            }
            Console.WriteLine(utazasszama + " fuvar alatt: " + bevetel + "$");
        }

        private static void UtakSzama(List<Fuvar> fuvarList)
        {
            Console.WriteLine(fuvarList.Count);
        }

    }
}