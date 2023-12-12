using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Teszteles
    {

        public class Csv
        {
            public int TaxiId { get; set; }
            public DateTime Datum { get; set; }
            public int Hossz { get; set; }
            public double Tavolsag { get; set; }
            public double Ar { get; set; }
            public double Tip { get; set; }
            public string FizetesiMod { get; set; }
        }

        private List<Csv> records = new List<Csv>();

        public int ElsoFeladat()
        {
            //semmi?
            return (0);
        }

        public int MasodikFeladat()
        {
            string file = "fuvar.csv";
          
            try
            {

                using (var reader = new StreamReader(file))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        if (values.Length >= 7)
                        {
                            Csv record = new Csv
                            {
                                TaxiId = int.Parse(values[0]),
                                Datum = DateTime.ParseExact(values[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                                Hossz = int.Parse(values[2]),
                                Tavolsag = double.Parse(values[3].Replace(',', '.'), CultureInfo.InvariantCulture),
                                Ar = double.Parse(values[4].Replace(',', '.'), CultureInfo.InvariantCulture),
                                Tip = double.Parse(values[5].Replace(',', '.'), CultureInfo.InvariantCulture),
                                FizetesiMod = values[6],
                            };

                            records.Add(record);
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                return 1;
                throw new Exception(ex.Message);
            }

                return 0;
        }

       public int HarmadikFeladat()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();
            int fuvarok = 0;

            foreach (var record in records)
            {
                fuvarok++;
            }


            return fuvarok;
        }

        public double NegyedikFeladatTaxi()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            double bevetel = 0;
            int taxiid = 6185;
            for(int i = 0; i< records.Count(); i++)
            {
                if (records[i].TaxiId == taxiid)
                {
                    bevetel += records[i].Ar + records[i].Tip;
                }
            }

            return bevetel;
        }
        
        public int NegyedikFeladatFuvar()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            int taxiid = 6185;
            int fuvarok = 0;
            for(int i = 0; i< records.Count(); i++)
            {
                if (records[i].TaxiId == taxiid)
                {
                    fuvarok++;
                }
            }

            return fuvarok;
        }

        public int OtodikFeladatKartya()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            string FizetesMod = "bankkártya";
            int count = 0;

            for(int i = 0; i< records.Count(); i++)
            {
                if (records[i].FizetesiMod == FizetesMod)
                {
                    count++;
                }
            }

            return count;
        }

        public int OtodikFeladatKP()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();
            
            string FizetesMod = "észpénz";
            int count = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                if (records[i].FizetesiMod == FizetesMod)
                {
                    count++;
                }
            }

            return count;
        }

        public int OtodikFeladatVitatott()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            string FizetesMod = "vitatott";
            int count = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                if (records[i].FizetesiMod == FizetesMod)
                {
                    count++;
                }
            }

            return count;
        }

        public int OtodikFeladatIngyen()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            string FizetesMod = "ingyenes";
            int count = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                if (records[i].FizetesiMod == FizetesMod)
                {
                    count++;
                }
            }

            return count;
        }

        public int OtodikFeladatIsmeretlen()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            string FizetesMod = "ismeretlen";
            int count = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                if (records[i].FizetesiMod == FizetesMod)
                {
                    count++;
                }
            }

            return count;
        }

        public double HatodikFeladat()
        {
            Teszteles ts = new Teszteles();
            ts.MasodikFeladat();

            double tav = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                tav = records[i].Tavolsag * 1.6;
            }


            return tav;
        }

        public static void Main(string[] args)
        {
            Teszteles teszteles = new Teszteles();
            teszteles.ElsoFeladat();
            teszteles.MasodikFeladat();
            teszteles.HarmadikFeladat();
            teszteles.NegyedikFeladatFuvar();
            teszteles.NegyedikFeladatTaxi();
            teszteles.OtodikFeladatIngyen();
            teszteles.OtodikFeladatVitatott();
            teszteles.OtodikFeladatKartya();
            teszteles.OtodikFeladatIsmeretlen();
            teszteles.OtodikFeladatKP();
            teszteles.HatodikFeladat();
        }
        
    }
}
