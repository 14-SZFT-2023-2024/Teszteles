using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladattesteles
{
    internal class Fuvar
    {
            public int taxiId { get; set; }
            public DateTime indulas { get; set; }
            public int idotartam { get; set; }
            public double tavolsag { get; set; }
            public double viteldij { get; set; }
            public double borravalo { get; set; }
            public string fizetes_modja { get; set; }

            public Fuvar(string line)
            {
                string[] sorokElvalasztva = line.Split(';');

                taxiId = Convert.ToInt32(sorokElvalasztva[0]);
                indulas = Convert.ToDateTime(sorokElvalasztva[1]);
                idotartam = Convert.ToInt32(sorokElvalasztva[2]);
                tavolsag = Convert.ToDouble(sorokElvalasztva[3]);
                viteldij = Convert.ToDouble(sorokElvalasztva[4]);
                borravalo = Convert.ToDouble(sorokElvalasztva[5]);
                fizetes_modja = sorokElvalasztva[6];
            }
    }
}
